namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedIdNamesOfPizzaAndToppingClasses : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PizzaToppings", new[] { "pizzaid" });
            CreateIndex("dbo.PizzaToppings", "pizzaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PizzaToppings", new[] { "pizzaId" });
            CreateIndex("dbo.PizzaToppings", "pizzaid");
        }
    }
}
