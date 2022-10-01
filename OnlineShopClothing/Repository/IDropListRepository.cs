using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopClothing.Repository
{
    public interface IDropListRepository<T> where T : class
    {
        public  IEnumerable<SelectListItem> GetItems();
    }
        
}
