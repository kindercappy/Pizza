namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPizzaClassForVegNonveg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizza", "veg", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pizza", "nonVeg", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizza", "nonVeg");
            DropColumn("dbo.Pizza", "veg");
        }
    }
}
