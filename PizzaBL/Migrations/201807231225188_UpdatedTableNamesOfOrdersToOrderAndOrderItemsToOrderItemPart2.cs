namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTableNamesOfOrdersToOrderAndOrderItemsToOrderItemPart2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.OrderItems", newName: "OrderItem");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OrderItem", newName: "OrderItems");
            RenameTable(name: "dbo.Order", newName: "Orders");
        }
    }
}
