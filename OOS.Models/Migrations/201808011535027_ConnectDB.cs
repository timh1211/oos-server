namespace OOS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        HashedPassword = c.String(),
                        Status = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.CreatedBy)
                .ForeignKey("dbo.Employee", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Avatar = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DigitalInformation",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
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
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        DeliveryTime = c.DateTime(nullable: false),
                        isLatest = c.Boolean(nullable: false),
                        isViewed = c.Int(nullable: false),
                        isSpecial = c.String(),
                        ManufacturerID = c.Guid(),
                        CategoryID = c.Guid(),
                        Status = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.Employee", t => t.CreatedBy)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerID)
                .ForeignKey("dbo.Employee", t => t.ModifiedBy)
                .Index(t => t.ManufacturerID)
                .Index(t => t.CategoryID)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OrderId })
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        CustomerId = c.Guid(),
                        EmployeeId = c.Guid(),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryTime = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(),
                        Star = c.Int(nullable: false),
                        Content = c.String(),
                        CustomerName = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        Like = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SupplierDetail",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SupplierId })
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Supplier", t => t.SupplierId)
                .Index(t => t.ProductId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierDetail", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.SupplierDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Review", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.DigitalInformation", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ModifiedBy", "dbo.Employee");
            DropForeignKey("dbo.Product", "ManufacturerID", "dbo.Manufacturer");
            DropForeignKey("dbo.Product", "CreatedBy", "dbo.Employee");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Account", "ModifiedBy", "dbo.Employee");
            DropForeignKey("dbo.Account", "CreatedBy", "dbo.Employee");
            DropIndex("dbo.SupplierDetail", new[] { "SupplierId" });
            DropIndex("dbo.SupplierDetail", new[] { "ProductId" });
            DropIndex("dbo.Review", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "EmployeeId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "ModifiedBy" });
            DropIndex("dbo.Product", new[] { "CreatedBy" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.Product", new[] { "ManufacturerID" });
            DropIndex("dbo.DigitalInformation", new[] { "ProductId" });
            DropIndex("dbo.Account", new[] { "ModifiedBy" });
            DropIndex("dbo.Account", new[] { "CreatedBy" });
            DropTable("dbo.Supplier");
            DropTable("dbo.SupplierDetail");
            DropTable("dbo.Review");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Product");
            DropTable("dbo.DigitalInformation");
            DropTable("dbo.Customer");
            DropTable("dbo.Category");
            DropTable("dbo.Employee");
            DropTable("dbo.Account");
        }
    }
}
