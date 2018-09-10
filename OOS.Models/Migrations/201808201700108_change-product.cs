namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "View", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Special", c => c.String());
            DropColumn("dbo.DigitalInformation", "Special");
            DropColumn("dbo.Product", "isViewed");
            DropColumn("dbo.Product", "isSpecial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "isSpecial", c => c.String());
            AddColumn("dbo.Product", "isViewed", c => c.Int(nullable: false));
            AddColumn("dbo.DigitalInformation", "Special", c => c.String());
            DropColumn("dbo.Product", "Special");
            DropColumn("dbo.Product", "View");
        }
    }
}
