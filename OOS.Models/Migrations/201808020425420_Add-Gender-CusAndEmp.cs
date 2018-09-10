namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderCusAndEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Gender");
            DropColumn("dbo.Employee", "Gender");
        }
    }
}
