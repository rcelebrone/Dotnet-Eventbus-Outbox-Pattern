using Microsoft.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Data {
    public class UserContext : DbContext {
        public UserContext (DbContextOptions<UserContext> options) : base(options) {}

        public DbSet<UserService.Entities.User> User { get; set; }
    }
}