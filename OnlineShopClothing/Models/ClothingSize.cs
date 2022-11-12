namespace OnlineShopClothing.Models
{
    public class ClothingSize
    {
        public int Id { get; set; }

        public int SizeId { get; set; }

        public Size Size { get; set; }

        public int ClothingId { get; set; } 

        public Clothing Clothing { get; set; }
    }
}
