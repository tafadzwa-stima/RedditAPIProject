using Microsoft.EntityFrameworkCore;
using RedditAPI.Models;

namespace RedditAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) :base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments {  get; set; }
    }
}
