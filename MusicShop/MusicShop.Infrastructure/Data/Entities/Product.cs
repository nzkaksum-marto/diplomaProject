using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string ProductName { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Picture { get; set; } = null!;
        [Required]
        [Range(0, 400, ErrorMessage = "Quantity must be between 0 and 400")]
        public int Quantity {  get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be 0.01 or higher")]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

        [Required]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
