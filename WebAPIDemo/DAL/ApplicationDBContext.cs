using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;

namespace WebAPIDemo.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base(options) { }

        public DbSet<Shirt> shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shirt>()
                .Property(x => x.ShirtId)
                .HasColumnName("Id");

            //Data seeding
            modelBuilder.Entity<Shirt>()
                .HasData(
                    new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Size = 42, Gender = "Male", Price = 29.99 },
                    new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Size = 40, Gender = "Female", Price = 25.99 },
                    new Shirt { ShirtId = 3, Brand = "Puma", Color = "Green", Size = 44, Gender = "Male", Price = 32.99 },
                    new Shirt { ShirtId = 4, Brand = "Reebok", Color = "Black", Size = 38, Gender = "Female", Price = 27.99 },
                    new Shirt { ShirtId = 5, Brand = "Under Armour", Color = "White", Size = 46, Gender = "Male", Price = 34.99 }
                );
        }
    }
}
