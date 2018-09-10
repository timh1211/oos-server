namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Image", "CreatedDate");
        }
    }
}
