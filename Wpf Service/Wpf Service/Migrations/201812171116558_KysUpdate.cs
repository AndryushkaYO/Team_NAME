namespace Wpf_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KysUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressModels", "ClientId", c => c.String());
            AddColumn("dbo.ClientModels", "OrderId", c => c.String());
            AddColumn("dbo.StoreModels", "OrderId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreModels", "OrderId");
            DropColumn("dbo.ClientModels", "OrderId");
            DropColumn("dbo.AddressModels", "ClientId");
        }
    }
}
