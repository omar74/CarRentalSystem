namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCarclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "clintid", c => c.Int());
            AddColumn("dbo.Cars", "From", c => c.DateTime());
            AddColumn("dbo.Cars", "To", c => c.DateTime());
            AddColumn("dbo.Cars", "duration", c => c.DateTime());
            CreateIndex("dbo.Cars", "clintid");
            AddForeignKey("dbo.Cars", "clintid", "dbo.Clints", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "clintid", "dbo.Clints");
            DropIndex("dbo.Cars", new[] { "clintid" });
            DropColumn("dbo.Cars", "duration");
            DropColumn("dbo.Cars", "To");
            DropColumn("dbo.Cars", "From");
            DropColumn("dbo.Cars", "clintid");
        }
    }
}
