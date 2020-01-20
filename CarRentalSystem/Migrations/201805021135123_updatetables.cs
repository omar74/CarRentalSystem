namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ImagePath", c => c.String());
            AddColumn("dbo.Clints", "blockstate", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Image", c => c.String());
            AlterColumn("dbo.Cars", "Name", c => c.String());
            DropColumn("dbo.Clints", "blockstate");
            DropColumn("dbo.Cars", "ImagePath");
        }
    }
}
