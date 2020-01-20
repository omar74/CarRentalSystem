namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clints", "username", c => c.String(nullable: false));
            AddColumn("dbo.Clints", "confirmpassword", c => c.String());
            AlterColumn("dbo.Clints", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clints", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Clints", "password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clints", "PreferedCarType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clints", "PreferedCarType", c => c.String());
            AlterColumn("dbo.Clints", "password", c => c.Int(nullable: false));
            AlterColumn("dbo.Clints", "Email", c => c.String());
            AlterColumn("dbo.Clints", "Name", c => c.String());
            DropColumn("dbo.Clints", "confirmpassword");
            DropColumn("dbo.Clints", "username");
        }
    }
}
