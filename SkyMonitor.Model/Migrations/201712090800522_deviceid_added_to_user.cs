namespace SkyMonitor.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deviceid_added_to_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DeviceId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DeviceId");
        }
    }
}
