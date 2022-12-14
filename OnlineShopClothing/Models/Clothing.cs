using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopClothing.Models
{
    public class Clothing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [ValidateNever]
        public List<ClothingSize> ClothingSizes { get; set; }

        [NotMapped]
        [ValidateNever]
        public string JoinedClothingSizes { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [ValidateNever]
        public Brand Brand { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Style { get; set; }

    }
}
