using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Clothing> Сlothing { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Size> Sizes { get; set; }
    }
}
