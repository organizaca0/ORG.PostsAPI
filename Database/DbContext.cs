using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Database
{
    public class DatabaseContext:DbContext
    {
        public IConfiguration _config { get; set; }
        public DatabaseContext(IConfiguration config) 
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DevDatabase"));
        }

        // tabelas
        public DbSet <Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchListPost> WatchListPosts { get; set; }
    }
}
