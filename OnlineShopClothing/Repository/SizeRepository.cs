using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class SizeRepository : ICheckBoxRepository<Size>
    {
        private readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> sizes = _context.Sizes.Select(item => new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString(),
                //isCheked = false
            }).ToList();
            return sizes;
        }
    }

}

