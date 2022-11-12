using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopClothing.Models;
using System.Reflection.Emit;

namespace OnlineShopClothing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothingSize>()
            .HasOne(s => s.Size)
            .WithMany(ms => ms.ClothingSizes)
            .HasForeignKey(si => si.SizeId);

            modelBuilder.Entity<ClothingSize>()
            .HasOne(c => c.Clothing)
            .WithMany(mc => mc.ClothingSizes)
            .HasForeignKey(ci => ci.ClothingId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Clothing> Сlothing { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<ClothingSize> ClothingSizes { get; set; }

    }
}
