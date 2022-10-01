using System.ComponentModel.DataAnnotations;

namespace OnlineShopClothing.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
