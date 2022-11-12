using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.ViewModels
{
    public class ClothingVM
    {
        public Clothing Clothing { get; set; } = new Clothing();

        [ValidateNever]

        public IEnumerable<Clothing> clothings { get; set; } = new List<Clothing>();

        [ValidateNever]

        public IEnumerable<SelectListItem> Categories { get; set; }

        [ValidateNever]
        public IList<SelectListItem> Sizes { get; set; }

        [ValidateNever]
        public IEnumerable<ClothingSize> ClothingSizes { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Brands { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
