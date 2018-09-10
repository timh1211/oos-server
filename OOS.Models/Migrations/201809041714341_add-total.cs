namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartDetail", "Total", c => c.Single(nullable: false));
            AddColumn("dbo.OrderDetail", "Total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetail", "Total");
            DropColumn("dbo.CartDetail", "Total");
        }
    }
}
