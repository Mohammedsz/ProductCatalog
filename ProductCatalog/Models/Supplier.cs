using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductCatalog.Models
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

        public virtual ICollection<Product> Products { get; set; }
    }
}