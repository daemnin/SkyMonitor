using SkyMonitor.Model.Contracts;
using System.Data.Entity;

namespace SkyMonitor.Model
{
    public class SkyMonitorContext : DbContext, IContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Location> Locations { get; set; }

        public SkyMonitorContext(): base("SkyMonitorContext")
        {
        }
    }
}
