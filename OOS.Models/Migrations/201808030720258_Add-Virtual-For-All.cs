namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualForAll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Employee_Id", c => c.Guid());
            AddColumn("dbo.Product", "Employee_Id", c => c.Guid());
            CreateIndex("dbo.Account", "Employee_Id");
            CreateIndex("dbo.Product", "Employee_Id");
            AddForeignKey("dbo.Account", "Employee_Id", "dbo.Employee", "Id");
            AddForeignKey("dbo.Product", "Employee_Id", "dbo.Employee", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.Account", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.Product", new[] { "Employee_Id" });
            DropIndex("dbo.Account", new[] { "Employee_Id" });
            DropColumn("dbo.Product", "Employee_Id");
            DropColumn("dbo.Account", "Employee_Id");
        }
    }
}
