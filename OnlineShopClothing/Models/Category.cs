﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopClothing.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
