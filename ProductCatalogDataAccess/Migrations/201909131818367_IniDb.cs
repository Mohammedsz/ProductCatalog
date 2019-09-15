namespace ProductCatalogDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        QuantityPerUnit = c.Single(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        UnitsInStock = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        UnitsOnOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
        }
    }
}
