namespace PizzaBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderClassToIncludeOrderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "orderStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "orderStatus");
        }
    }
}
