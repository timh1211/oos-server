namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetimeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Account", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
