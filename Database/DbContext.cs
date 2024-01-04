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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts) // A User can have many Posts
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<WatchList>().HasKey(e => e.WatchListId);
            base.OnModelCreating(modelBuilder);
        }
        // tabelas
        public DbSet <Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
    }
}
