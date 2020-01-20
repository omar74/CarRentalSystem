namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataAnonntation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "color", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "color", c => c.String());
            AlterColumn("dbo.Cars", "Model", c => c.String());
        }
    }
}
