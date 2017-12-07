namespace SkyMonitor.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class push_notifications_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Users", "PhoneId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PhoneId");
            DropColumn("dbo.Devices", "Name");
        }
    }
}
