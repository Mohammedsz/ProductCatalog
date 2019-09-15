using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductCatalog.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(length: 50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Minimum amount to sell")]
        public float QuantityPerUnit { get; set; }

        [Required]
        [Display(Name = "Minimum amount to store")]
        public int ReorderLevel { get; set; }

        [Required]
        [Display(Name = "Price for one unit")]
        public float UnitPrice { get; set; }

        [Required]
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [Required]
        [Display(Name = "Supplier name")]
        public int SupplierName { get; set; }

        [Display(Name = "Amount of units in one order")]
        public int UnitsOnOrder { get; set; }
    }
}