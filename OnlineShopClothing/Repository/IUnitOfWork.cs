using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IClothingRepository Clothing { get; }

        IDropListRepository<Brand> Brand { get; }

        IDropListRepository<Country> Country { get; }

        ICheckBoxRepository<Size> Size { get; }

        IClothingSizeRepository<ClothingSize> ClothingSize { get; }

        void Save();
    }
}
