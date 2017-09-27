namespace AuthTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationTracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsages",
                c => new
                    {
                        ApplicationUsageID = c.Int(nullable: false, identity: true),
                        ApplicationID = c.Int(nullable: false),
                        TrackedApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationUsageID)
                .ForeignKey("dbo.TrackedApplications", t => t.TrackedApplicationID, cascadeDelete: true)
                .Index(t => t.TrackedApplicationID);
            
            CreateTable(
                "dbo.TrackedApplications",
                c => new
                    {
                        TrackedApplicationID = c.Int(nullable: false, identity: true),
                        TrackedApplicationName = c.String(),
                    })
                .PrimaryKey(t => t.TrackedApplicationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsages", "TrackedApplicationID", "dbo.TrackedApplications");
            DropIndex("dbo.ApplicationUsages", new[] { "TrackedApplicationID" });
            DropTable("dbo.TrackedApplications");
            DropTable("dbo.ApplicationUsages");
        }
    }
}
