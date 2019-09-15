using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogDataAccess.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(length: 50)]
        public string ProductName { get; set; }

        [Required]
        public float QuantityPerUnit { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public int UnitsOnOrder { get; set; }

        public SupplierDto Supplier { get; set; }
    }
}
