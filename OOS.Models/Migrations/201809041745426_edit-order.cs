namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editorder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Total", c => c.Single(nullable: false));
            DropColumn("dbo.Order", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Code", c => c.String());
            AlterColumn("dbo.Order", "Total", c => c.Int(nullable: false));
        }
    }
}
