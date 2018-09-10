namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "EmployeeID", c => c.Guid());
            CreateIndex("dbo.Account", "EmployeeID");
            AddForeignKey("dbo.Account", "EmployeeID", "dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Account", new[] { "EmployeeID" });
            DropColumn("dbo.Account", "EmployeeID");
        }
    }
}
