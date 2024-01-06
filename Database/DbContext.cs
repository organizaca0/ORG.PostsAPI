using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Controllers;
using ORG.PostsAPI.Models;

namespace ORG.PostsAPI.Database
{
    public class DatabaseContext:DbContext
    {
        public IConfiguration Config { get; set; }
        public DatabaseContext(IConfiguration config) 
        {
            Config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("DevDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Post>()
                .HasKey(p => p.PostGuid);

            builder.Entity<WatchList>()
                .HasKey(e => e.WatchListGuid);
            base.OnModelCreating(builder);
        }
        // tabelas
        public DbSet <Post> Posts { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
    }
}
