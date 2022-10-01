using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public ICategoryRepository Category { get; private set; }

        public IClothingRepository Clothing { get; private set; }

        public IDropListRepository<Brand> Brand {get; private set;}

        public IDropListRepository<Country> Country { get; private set; }

        public IDropListRepository<Size> Size { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Category = new CategoryRepository(context);

            Clothing = new ClothingRepository(context);

            Brand = new BrandRepository(context);

            Country = new CountryRepository(context);   

            Size = new SizeRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
