using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopClothing.Data;
using OnlineShopClothing.Models;

namespace OnlineShopClothing.Repository
{
    public class ClothingSizeRepository : IClothingSizeRepository<ClothingSize>
    {
        private readonly ApplicationDbContext _context;

        private DbSet<ClothingSize> _dbSet;

        public ClothingSizeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ClothingSize>();
        }


        public void Add(ClothingSize entity)
        {
            _context.Add(entity);
        }

        public void Delete(int sizeId)
        {
            _context?.Remove(sizeId);
        }

        public IEnumerable<ClothingSize> GetItemsByClothingId(int clothingId)
        {
            List<ClothingSize> clothingSize = _context.ClothingSizes.Where(cs => cs.ClothingId == clothingId).ToList();
            return clothingSize;
        }

        public IEnumerable<ClothingSize> GetItems()
        {
            List<ClothingSize> clothingSize = _context.ClothingSizes.ToList();
            return clothingSize;
        }


    }
}