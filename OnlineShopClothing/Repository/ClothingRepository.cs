using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class ClothingRepository : Repository<Clothing>, IClothingRepository
    {
        private ApplicationDbContext _context;

        public ClothingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpDate(Clothing clothing)
        {
            var clothingDb = _context.Сlothing.FirstOrDefault(x => x.Id == clothing.Id);
            if(clothingDb != null)
            {
                clothingDb.Name = clothing.Name;
                clothingDb.Description = clothing.Description;
                clothingDb.Price = clothing.Price;
                clothingDb.Color = clothing.Color;
                clothingDb.Style = clothing.Style;
                if(clothing.ImageUrl != null)
                {
                    clothingDb.ImageUrl = clothing.ImageUrl;
                }
              
            }
        }
    }
}
