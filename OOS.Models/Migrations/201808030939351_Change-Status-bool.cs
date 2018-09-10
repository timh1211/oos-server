namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatusbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Account", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employee", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Order", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customer", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Supplier", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supplier", "Status", c => c.String());
            AlterColumn("dbo.Product", "Status", c => c.String());
            AlterColumn("dbo.Customer", "Status", c => c.String());
            AlterColumn("dbo.Order", "Status", c => c.String());
            AlterColumn("dbo.Employee", "Status", c => c.String());
            AlterColumn("dbo.Account", "Status", c => c.String());
            DropColumn("dbo.Review", "Status");
        }
    }
}
