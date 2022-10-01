using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class CountryRepository : IDropListRepository<Country>
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> countries = _context.Countries.OrderBy(x => x.Id).Select(x =>
                    new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name,
                    }).ToList();
            return new SelectList(countries, "Value", "Text");
        }
    }
}
