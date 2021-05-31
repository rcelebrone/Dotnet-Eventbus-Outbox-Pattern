using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostService.Entities;
using PostService.Data;
using Microsoft.EntityFrameworkCore; //ToListAsync

namespace PostServiceService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            return await _context.Post.Include(x => x.User).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post) {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPost", new { id = post.PostId}, post);
        }
    }
}
