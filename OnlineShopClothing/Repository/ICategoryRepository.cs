using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public interface ICategoryRepository : IRepository<Category>, IDropListRepository<Category>
    {
        void Update(Category category);
    }
}
