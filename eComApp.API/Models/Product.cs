using System;
using System.ComponentModel.DataAnnotations;

namespace eComApp.API.Models
{
    public class Product
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Prodcut Name required")]
        public string Name { get; set; }
       [Required(ErrorMessage = "Prodcut Category required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Unit Price required")]
        public decimal UnitPrice { get; set; }
        public int? AvilableQty { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}