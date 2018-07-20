namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        pizzaid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        pizzaBase = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pizzaid);
            
            CreateTable(
                "dbo.PizzaToppings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pizzaid = c.Int(nullable: false),
                        toppingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pizza", t => t.pizzaid, cascadeDelete: true)
                .Index(t => t.pizzaid);
            
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
            DropForeignKey("dbo.PizzaToppings", "pizzaid", "dbo.Pizza");
            DropIndex("dbo.PizzaToppings", new[] { "pizzaid" });
            DropTable("dbo.Toppings");
            DropTable("dbo.PizzaToppings");
            DropTable("dbo.Pizza");
        }
    }
}
