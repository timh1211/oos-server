namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addispayorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "IsPayed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Discount", c => c.Single(nullable: false));
            //AlterColumn("dbo.Product", "DeliveryTime", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "DeliveryDays", c => c.Int());
            Sql("Update dbo.Product SET DeliveryDays = Convert(int, DeliveryTime)");
            DropColumn("dbo.Product", "DeliveryTime");
            RenameColumn("dbo.Product", "DeliveryDays", "DeliveryTime");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "DeliveryTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "IsPayed");
        }
    }
}
