using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public interface IClothingRepository : IRepository<Clothing>
    {
        void UpDate(Clothing Сlothing);
    }
}
