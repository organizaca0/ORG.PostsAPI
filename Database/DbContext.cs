using Microsoft.EntityFrameworkCore;
using ORG.PostsAPI.Controllers;
using ORG.PostsAPI.Models;
using System.Reflection.Emit;

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

            builder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserGuid);

            builder.Entity<WatchList>()
                .HasKey(e => e.WatchListGuid);

            builder.Entity<WatchList>()
            .HasOne(p => p.User)
            .WithMany(u => u.Watchs)
            .HasForeignKey(p => p.UserGuid);

            base.OnModelCreating(builder);
        }
        // tabelas
        public DbSet<User> Users { get; set; }
        public DbSet <Post> Posts { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
    }
}
