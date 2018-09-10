namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editproduct001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "DeliveryDays", c => c.Int());
            Sql("Update dbo.Product SET DeliveryDays = Convert(int, DeliveryTime)");
            DropColumn("dbo.Product", "DeliveryTime");
            RenameColumn("dbo.Product", "DeliveryDays", "DeliveryTime");
        }
        
        public override void Down()
        {
        }
    }
}
