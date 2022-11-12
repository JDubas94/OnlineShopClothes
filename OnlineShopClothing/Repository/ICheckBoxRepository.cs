using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopClothing.Repository
{
    public interface ICheckBoxRepository<T> where T : class
    {
        public IEnumerable<SelectListItem> GetItems();
    }
   
}
