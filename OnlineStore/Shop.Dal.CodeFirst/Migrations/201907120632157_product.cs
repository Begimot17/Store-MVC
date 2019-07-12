namespace Store.Dal.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Manufacturer_Id", newName: "IX_ManufacturerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_ManufacturerId", newName: "IX_Manufacturer_Id");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Products", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
        }
    }
}
