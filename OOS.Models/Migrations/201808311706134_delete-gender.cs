namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletegender : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Gender", c => c.Int(nullable: false));
        }
    }
}
