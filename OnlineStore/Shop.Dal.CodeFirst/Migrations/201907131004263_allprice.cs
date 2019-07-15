namespace Store.Dal.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AllPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "AllPrice");
        }
    }
}
