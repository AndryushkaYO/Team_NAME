namespace Wpf_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyUpte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModels", "OrderKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductModels", "OrderKey");
        }
    }
}
