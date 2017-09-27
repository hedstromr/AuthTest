namespace AuthTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUsageTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsages", "InvocationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ApplicationUsages", "ApplicationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsages", "ApplicationID", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUsages", "InvocationTime");
        }
    }
}
