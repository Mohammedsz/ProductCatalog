using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogDataAccess.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int SupplierId { get; set; }

        [Required()]
        public string SupplierName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
