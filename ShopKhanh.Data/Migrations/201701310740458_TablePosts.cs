namespace ShopKhanh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablePosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ViewCount");
        }
    }
}
