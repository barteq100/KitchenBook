namespace KitchenBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "dishType", c => c.Int(nullable: false));
            AddColumn("dbo.Dishes", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "Rate");
            DropColumn("dbo.Dishes", "dishType");
        }
    }
}
