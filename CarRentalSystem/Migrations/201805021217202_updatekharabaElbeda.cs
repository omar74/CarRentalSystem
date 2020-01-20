namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekharabaElbeda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clints", "categorytypeid", c => c.Int(nullable: false));
            AddColumn("dbo.Clints", "categorytypeId_id", c => c.Int());
            CreateIndex("dbo.Clints", "categorytypeId_id");
            AddForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories");
            DropIndex("dbo.Clints", new[] { "categorytypeId_id" });
            DropColumn("dbo.Clints", "categorytypeId_id");
            DropColumn("dbo.Clints", "categorytypeid");
        }
    }
}
