namespace ShopKhanh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerAddress", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerAddress");
        }
    }
}
