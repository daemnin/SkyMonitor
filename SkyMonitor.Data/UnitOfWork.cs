using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using SkyMonitor.Model.Contracts;
using System;

namespace SkyMonitor.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContext context;
        private bool disposed;

        public UnitOfWork(IContext context)
        {
            this.context = context;
        }

        private IRepository<User> userRepository;
        public IRepository<User> UserRepository => userRepository ?? (userRepository = new Repository<User>(context));

        private IRepository<Device> deviceRepository;
        public IRepository<Device> DeviceRepository => deviceRepository ?? (deviceRepository = new Repository<Device>(context));

        private IRepository<Location> locationRepository;
        public IRepository<Location> LocationRepository => locationRepository ?? (locationRepository = new Repository<Location>(context));

        private IRepository<Alarm> alarmRepository;
        public IRepository<Alarm> AlarmRepository => alarmRepository ?? (alarmRepository = new Repository<Alarm>(context));

        public void Dispose()
        {
            if (!disposed)
            {
                context.Dispose();
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        public int Save()
        {
            int changes = 0;
            if (!disposed && context.ChangeTracker.HasChanges())
            {
                changes = context.SaveChanges();
            }
            return changes;
        }
    }
}
