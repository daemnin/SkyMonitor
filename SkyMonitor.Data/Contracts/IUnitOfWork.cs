using SkyMonitor.Model;
using System;

namespace SkyMonitor.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Device> DeviceRepository { get; }
        IRepository<Location> LocationRepository { get; }
        int Save();
    }
}
