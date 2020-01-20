namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "duration", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "duration", c => c.DateTime());
        }
    }
}
