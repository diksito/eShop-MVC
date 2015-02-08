namespace ShopMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "ProductId", c => c.String());
            AddColumn("dbo.Baskets", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "Quantity");
            DropColumn("dbo.Baskets", "ProductId");
        }
    }
}
