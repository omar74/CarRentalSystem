namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfieldPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clints", "Password", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clints", "Password");
        }
    }
}
