namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditPriceType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetail", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderDetail", "Discount", c => c.Single(nullable: false));
            AlterColumn("dbo.SupplierDetail", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SupplierDetail", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetail", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetail", "Price", c => c.Int(nullable: false));
        }
    }
}
