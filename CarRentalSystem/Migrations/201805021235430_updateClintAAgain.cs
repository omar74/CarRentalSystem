namespace CarRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateClintAAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clints", "categorytypeid");
            RenameColumn(table: "dbo.Clints", name: "categorytypeId_id", newName: "categorytypeid");
            RenameIndex(table: "dbo.Clints", name: "IX_categorytypeId_id", newName: "IX_categorytypeid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Clints", name: "IX_categorytypeid", newName: "IX_categorytypeId_id");
            RenameColumn(table: "dbo.Clints", name: "categorytypeid", newName: "categorytypeId_id");
            AddColumn("dbo.Clints", "categorytypeid", c => c.Int(nullable: false));
        }
    }
}
