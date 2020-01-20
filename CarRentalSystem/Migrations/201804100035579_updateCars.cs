namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCars : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "duration", c => c.Time(precision: 7));
        }
    }
}
