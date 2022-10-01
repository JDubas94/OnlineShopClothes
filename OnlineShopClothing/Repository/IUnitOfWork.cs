using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IClothingRepository Clothing { get; }

        IDropListRepository<Brand> Brand { get; }

        IDropListRepository<Country> Country { get; }

        IDropListRepository<Size> Size { get; }
        void Save();
    }
}
