namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        orderItemId = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        pizzaItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderItemId)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        customerName = c.String(),
                        customerPhone = c.String(),
                    })
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        pizzaId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        pizzaBase = c.Int(nullable: false),
                        veg = c.Boolean(nullable: false),
                        nonVeg = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pizzaId);
            
            CreateTable(
                "dbo.PizzaToppings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pizzaId = c.Int(nullable: false),
                        toppingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pizza", t => t.pizzaId, cascadeDelete: true)
                .Index(t => t.pizzaId);
            
            CreateTable(
                "dbo.Toppings",
                c => new
                    {
                        toppingId = c.Int(nullable: false, identity: true),
                        topping = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.toppingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaToppings", "pizzaId", "dbo.Pizza");
            DropForeignKey("dbo.OrderItems", "orderId", "dbo.Orders");
            DropIndex("dbo.PizzaToppings", new[] { "pizzaId" });
            DropIndex("dbo.OrderItems", new[] { "orderId" });
            DropTable("dbo.Toppings");
            DropTable("dbo.PizzaToppings");
            DropTable("dbo.Pizza");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
