using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductCatalogService.Controllers
{
    public class AllProductsViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(length: 50)]
        public string ProductName { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required()]
        public string SupplierName { get; set; }
    }
}