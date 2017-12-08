namespace SkyMonitor.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status_to_device : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Status");
        }
    }
}
