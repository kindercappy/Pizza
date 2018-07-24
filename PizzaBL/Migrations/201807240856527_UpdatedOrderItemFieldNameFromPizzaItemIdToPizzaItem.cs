namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderItemFieldNameFromPizzaItemIdToPizzaItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "pizzaItem", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItem", "pizzaItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItem", "pizzaItemId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItem", "pizzaItem");
        }
    }
}
