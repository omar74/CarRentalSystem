namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekharaba : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories");
            DropIndex("dbo.Clints", new[] { "categorytypeId_id" });
            AlterColumn("dbo.Clints", "PreferedCarType", c => c.String());
            AlterColumn("dbo.Clints", "categorytypeId_id", c => c.Int(nullable: true));
            CreateIndex("dbo.Clints", "categorytypeId_id");
            AddForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories");
            DropIndex("dbo.Clints", new[] { "categorytypeId_id" });
            AlterColumn("dbo.Clints", "categorytypeId_id", c => c.Int());
            AlterColumn("dbo.Clints", "PreferedCarType", c => c.String(nullable: false));
            CreateIndex("dbo.Clints", "categorytypeId_id");
            AddForeignKey("dbo.Clints", "categorytypeId_id", "dbo.Categories", "id");
        }
    }
}
