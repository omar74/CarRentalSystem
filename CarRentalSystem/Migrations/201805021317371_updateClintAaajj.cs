namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateClintAaajj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false));
        }
    }
}
