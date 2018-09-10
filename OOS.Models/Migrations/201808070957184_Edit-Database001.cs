namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Product", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.Account", new[] { "Employee_Id" });
            DropIndex("dbo.Product", new[] { "Employee_Id" });
            DropColumn("dbo.Account", "Employee_Id");
            DropColumn("dbo.Product", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Employee_Id", c => c.Guid());
            AddColumn("dbo.Account", "Employee_Id", c => c.Guid());
            CreateIndex("dbo.Product", "Employee_Id");
            CreateIndex("dbo.Account", "Employee_Id");
            AddForeignKey("dbo.Product", "Employee_Id", "dbo.Employee", "Id");
            AddForeignKey("dbo.Account", "Employee_Id", "dbo.Employee", "Id");
        }
    }
}
