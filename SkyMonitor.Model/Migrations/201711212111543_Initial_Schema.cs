namespace SkyMonitor.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial_Schema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Range = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDevices",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Device_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Device_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.Device_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Device_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDevices", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.UserDevices", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Locations", "DeviceId", "dbo.Devices");
            DropIndex("dbo.UserDevices", new[] { "Device_Id" });
            DropIndex("dbo.UserDevices", new[] { "User_Id" });
            DropIndex("dbo.Locations", new[] { "DeviceId" });
            DropTable("dbo.UserDevices");
            DropTable("dbo.Users");
            DropTable("dbo.Locations");
            DropTable("dbo.Devices");
        }
    }
}
