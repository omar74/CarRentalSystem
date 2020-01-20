namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatadeclation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "categortypeid", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "CategorytypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CategorytypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "categortypeid");
        }
    }
}
