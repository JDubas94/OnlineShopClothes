using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class BrandRepository : IDropListRepository<Brand>
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> brands = _context.Brands.OrderBy(x => x.Name).Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    }).ToList();
            return new SelectList(brands, "Value", "Text");
        }
    }
}

