using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class SizeRepository : IDropListRepository<Size>
    {
        private readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> sizes = _context.Sizes.OrderBy(x => x.Id).Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    }).ToList();
            return new SelectList(sizes, "Value", "Text");
        }
    }
}

