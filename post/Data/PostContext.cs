using Microsoft.EntityFrameworkCore;

namespace PostService.Data
{
    public class PostContext : DbContext
    {
        public PostContext (DbContextOptions<PostContext> options) : base(options) {}

        public DbSet<PostService.Entities.Post> Post { get; set; }
        public DbSet<PostService.Entities.User> User { get; set; }
    }
}