namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcontact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Code", c => c.String());
        }
    }
}
