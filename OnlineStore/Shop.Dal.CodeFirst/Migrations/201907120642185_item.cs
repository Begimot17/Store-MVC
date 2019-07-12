namespace Store.Dal.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class item : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.Items", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Items", name: "IX_Product_Id", newName: "IX_ProductId");
            RenameIndex(table: "dbo.Items", name: "IX_Order_Id", newName: "IX_OrderId");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Items", name: "IX_OrderId", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.Items", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Items", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Items", name: "OrderId", newName: "Order_Id");
        }
    }
}
