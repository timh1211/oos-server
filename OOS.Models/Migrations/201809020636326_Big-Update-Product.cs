namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigUpdateProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DigitalInformation",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Monitor = c.String(),
                    OperatingSystem = c.String(),
                    CPU = c.String(),
                    RAM = c.Int(nullable: false),
                    InternalMemory = c.Int(nullable: false),
                    HardDrive = c.String(),
                    GraphicCard = c.String(),
                    BehindCamera = c.String(),
                    FrontCamera = c.String(),
                    NetworkConnection = c.String(),
                    Connector = c.String(),
                    Weight = c.String(),
                    Special = c.String(),
                    Design = c.String(),
                    Size = c.String(),
                    MemoryCard = c.String(),
                    SIMCard = c.String(),
                    Conversation = c.String(),
                    BatteryCapacity = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Image",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    name = c.String(),
                    originName = c.String(),
                    path = c.String(),
                    extension = c.String(),
                    size = c.Double(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            AddForeignKey("dbo.Product", "Id", "dbo.DigitalInformation", "Id");
            AddForeignKey("dbo.Product", "Id", "dbo.Image", "Id");
        }
        
        public override void Down()
        {
            DropTable("dbo.DigitalInformation");
            DropTable("dbo.Image");
            DropIndex("dbo.DigitalInformation", new[] { "Id" });
            DropIndex("dbo.Image", new[] { "Id" });
            DropForeignKey("dbo.DigitalInformation", "Id", "dbo.Product");
            DropForeignKey("dbo.Image", "Id", "dbo.Product");
        }
    }
}
