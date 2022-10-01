using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> categories = _context.Categories.OrderBy(x => x.Name).Select(x =>
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            return new SelectList(categories, "Value", "Text");
        }

        public void Update(Category category)
        {
            var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (categoryDB != null)
            {
                categoryDB.Name = category.Name;
            }
        }
    }
}
