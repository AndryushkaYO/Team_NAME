namespace Wpf_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        AddressKey = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressModels", t => t.AddressKey)
                .Index(t => t.AddressKey);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClientKey = c.String(maxLength: 128),
                        StoreId = c.String(maxLength: 128),
                        ProdId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientModels", t => t.ClientKey)
                .ForeignKey("dbo.ProductModels", t => t.ProdId)
                .ForeignKey("dbo.StoreModels", t => t.StoreId)
                .Index(t => t.ClientKey)
                .Index(t => t.StoreId)
                .Index(t => t.ProdId);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.StoreModels",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        AddressKey = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.AddressModels", t => t.AddressKey)
                .Index(t => t.AddressKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StoreId", "dbo.StoreModels");
            DropForeignKey("dbo.StoreModels", "AddressKey", "dbo.AddressModels");
            DropForeignKey("dbo.Orders", "ProdId", "dbo.ProductModels");
            DropForeignKey("dbo.Orders", "ClientKey", "dbo.ClientModels");
            DropForeignKey("dbo.ClientModels", "AddressKey", "dbo.AddressModels");
            DropIndex("dbo.StoreModels", new[] { "AddressKey" });
            DropIndex("dbo.Orders", new[] { "ProdId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropIndex("dbo.Orders", new[] { "ClientKey" });
            DropIndex("dbo.ClientModels", new[] { "AddressKey" });
            DropTable("dbo.StoreModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.Orders");
            DropTable("dbo.ClientModels");
            DropTable("dbo.AddressModels");
        }
    }
}
