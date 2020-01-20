namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatforignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "categorytypeid_id", "dbo.Categories");
            DropIndex("dbo.Cars", new[] { "categorytypeid_id" });
            RenameColumn(table: "dbo.Cars", name: "categorytypeid_id", newName: "categorytypeid");
            AlterColumn("dbo.Cars", "categorytypeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "categorytypeid");
            AddForeignKey("dbo.Cars", "categorytypeid", "dbo.Categories", "id", cascadeDelete: true);
            DropColumn("dbo.Cars", "categortypeid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "categortypeid", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "categorytypeid", "dbo.Categories");
            DropIndex("dbo.Cars", new[] { "categorytypeid" });
            AlterColumn("dbo.Cars", "categorytypeid", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "categorytypeid", newName: "categorytypeid_id");
            CreateIndex("dbo.Cars", "categorytypeid_id");
            AddForeignKey("dbo.Cars", "categorytypeid_id", "dbo.Categories", "id");
        }
    }
}
