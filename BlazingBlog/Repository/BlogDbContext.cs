using BlazingBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Repository
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blazingblog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost { Id = 1, Title = "First post", Content = "This is the first post" },
                new BlogPost { Id = 2, Title = "Second post", Content = "This is the second post" },
                new BlogPost { Id = 3, Title = "Third post", Content = "This is the third post" }
            );
        }
    }
}
