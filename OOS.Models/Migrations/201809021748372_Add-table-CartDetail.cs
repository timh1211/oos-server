namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtableCartDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDetail",
                c => new
                    {
                        CustomerId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.ProductId })
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CartDetail", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CartDetail", new[] { "ProductId" });
            DropIndex("dbo.CartDetail", new[] { "CustomerId" });
            DropTable("dbo.CartDetail");
        }
    }
}
