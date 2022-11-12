using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public interface IClothingSizeRepository<T>  where T : class
    {
        public IEnumerable<T> GetItemsByClothingId(int clothingId);

        public IEnumerable<T> GetItems();
        public void Add(T entity);
        public void Delete(int entity);

    }
}
