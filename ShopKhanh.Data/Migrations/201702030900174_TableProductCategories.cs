namespace ShopKhanh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableProductCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Image", c => c.String(maxLength: 256));
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ProductCategories", "Alias", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ProductCategories", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.ProductCategories", "Images");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "Images", c => c.String());
            AlterColumn("dbo.ProductCategories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.ProductCategories", "Alias", c => c.String());
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ProductCategories", "Image");
        }
    }
}
