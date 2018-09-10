namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetotal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartDetail", "Total");
            DropColumn("dbo.OrderDetail", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetail", "Total", c => c.Single(nullable: false));
            AddColumn("dbo.CartDetail", "Total", c => c.Single(nullable: false));
        }
    }
}
