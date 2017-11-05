namespace KitchenBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DishUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingridients", "Dish_Id", c => c.Int());
            CreateIndex("dbo.Ingridients", "Dish_Id");
            AddForeignKey("dbo.Ingridients", "Dish_Id", "dbo.Dishes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingridients", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.Ingridients", new[] { "Dish_Id" });
            DropColumn("dbo.Ingridients", "Dish_Id");
        }
    }
}
