namespace SkyMonitor.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class device_location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Devices", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Longitude");
            DropColumn("dbo.Devices", "Latitude");
        }
    }
}
