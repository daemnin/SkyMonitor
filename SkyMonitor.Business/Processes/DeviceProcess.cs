using SkyMonitor.Commons.Entities;
using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using System;

namespace SkyMonitor.Business.Processes
{
    public class DeviceProcess : ProcessBase
    {
        public DeviceProcess(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Response Create(int id, string name, int range)
        {
            var response = new Response();

            try
            {
                var device = new Device
                {
                    Id = id,
                    Name = name,
                    Range = range,
                    Status = StatusType.Disarmed
                };

                UnitOfWork.DeviceRepository.Create(device);

                response.Succeeded = UnitOfWork.Save() > 0;
            }
            catch (Exception ex)
            {
                FillErrors(ex, response);
            }

            return response;
        }

        public Response Assign(int deviceId, string phone)
        {
            var response = new Response();

            try
            {
                var user = UnitOfWork.UserRepository.Read(u => u.Phone.Equals(phone), u => u.Devices);
                var device = UnitOfWork.DeviceRepository.Read(deviceId, d => d.Users);

                user.Devices.Add(device);

                device.Users.Add(user);

                response.Succeeded = UnitOfWork.Save() > 0;
            }
            catch (Exception ex)
            {
                FillErrors(ex, response);
            }

            return response;
        }
    }
}
