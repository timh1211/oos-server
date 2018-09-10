namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountComplex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Username", c => c.String(maxLength: 50));
            CreateIndex("dbo.Account", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Account", new[] { "Username" });
            AlterColumn("dbo.Account", "Username", c => c.String());
        }
    }
}
