﻿using MusicShop.Models.Brand;
using MusicShop.Models.Category;

using System.ComponentModel.DataAnnotations;

namespace MusicShop.Models.Product
{
    public class ProductEditVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; } = new List<BrandPairVM>();

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;
        [Range(0, 500)]
        [Display(Name ="Quantity")]
        public int Quantity { get; set; }
        [Range(0, 50000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Range(0, 100)]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
