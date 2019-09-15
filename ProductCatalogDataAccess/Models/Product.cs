using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogDataAccess.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(length:50)]
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

        public  Supplier Supplier { get; set; }
    }

    public class ProductConfigration : EntityTypeConfiguration<Product>
    {
        public ProductConfigration()
        {
            HasRequired(t => t.Supplier).WithMany(t => t.Products).HasForeignKey(t => t.SupplierId).WillCascadeOnDelete(false);
        }
    }
}
