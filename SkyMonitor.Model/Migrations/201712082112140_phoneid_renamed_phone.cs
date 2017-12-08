namespace SkyMonitor.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class phoneid_renamed_phone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.Users", "PhoneId");
        }

        public override void Down()
        {
            AddColumn("dbo.Users", "PhoneId", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Phone");
        }
    }
}