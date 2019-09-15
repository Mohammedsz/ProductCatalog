using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogDataAccess.Dtos
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }

        [Required()]
        public string SupplierName { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
