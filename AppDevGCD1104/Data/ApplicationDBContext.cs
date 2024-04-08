using AppDevGCD1104.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppDevGCD1104.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> books { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Adventure", Description = "So funny" },
                new Category { Id = 2, Name = "Roman", Description = "So romantic" },
                new Category { Id = 3, Name = "Horror", Description = "So scary" },
                new Category { Id = 4, Name = "Science", Description = "So Boring" }
               );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "sdfsf", Description = "So funny", Author = "vsfsd", CategoryId = 1, ImgUrl = "" },
                new Book { Id = 2, Title = "Rvsvsoman", Description = "So romantic", Author = "sfsv", CategoryId = 2, ImgUrl = "" },
                new Book { Id = 3, Title = "Horsvsvsror", Description = "So scary", Author = "vsvsv", CategoryId = 3, ImgUrl = "" },
                new Book { Id = 4, Title = "Scivsssence", Description = "So Boring", Author = "vsfsdf", CategoryId = 4, ImgUrl = "" }
               );
        }
    }
}
