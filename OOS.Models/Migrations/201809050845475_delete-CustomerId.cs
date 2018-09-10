namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteCustomerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Order", new[] { "EmployeeId" });
            DropColumn("dbo.Order", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "EmployeeId", c => c.Guid());
            CreateIndex("dbo.Order", "EmployeeId");
            AddForeignKey("dbo.Order", "EmployeeId", "dbo.Employee", "Id");
        }
    }
}
