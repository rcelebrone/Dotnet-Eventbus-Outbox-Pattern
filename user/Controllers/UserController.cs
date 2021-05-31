using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Entities;
using UserService.Data;
using Microsoft.EntityFrameworkCore; //ToListAsync
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            user.ID = id;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            PublishToMessageQueue("user.update", JsonConvert.SerializeObject(new
            {
                id = user.ID,
                newname = user.Name
            }));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            PublishToMessageQueue("user.add", JsonConvert.SerializeObject(new
            {
                id = user.ID,
                name = user.Name
            }));

            return CreatedAtAction("GetUser", new { id = user.ID}, user);
        }
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            // TOOO: Reuse and close connections and channel, etc, 
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "user",
                                             routingKey: integrationEvent,
                                             basicProperties: null,
                                             body: body);
        }
    }
}
