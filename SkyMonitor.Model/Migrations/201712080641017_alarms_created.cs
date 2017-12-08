namespace SkyMonitor.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alarms_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alarms",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "Id", "dbo.Devices");
            DropIndex("dbo.Alarms", new[] { "Id" });
            DropTable("dbo.Alarms");
        }
    }
}
