using SkyMonitor.Commons.Entities;
using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using System;

namespace SkyMonitor.Business.Processes
{
    public class AlarmProcess : ProcessBase
    {
        public AlarmProcess(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Response Activate(int deviceId)
        {
            var response = new Response();

            try
            {
                var device = UnitOfWork.DeviceRepository.Read(deviceId);

                if (device.Status != StatusType.Disarmed) throw new Exception("La alarma no puede ser activada.");

                var alarm = new Alarm
                {
                    Id = device.Id,
                    Latitude = device.Latitude,
                    Longitude = device.Longitude
                };

                device.Status = StatusType.Armed;

                UnitOfWork.AlarmRepository.Create(alarm);

                UnitOfWork.DeviceRepository.Update(device);

                response.Succeeded = UnitOfWork.Save() > 0;
            }
            catch (Exception ex)
            {
                FillErrors(ex, response);
            }

            return response;
        }

        public Response Disable(int deviceId)
        {
            var response = new Response();

            try
            {
                var device = UnitOfWork.DeviceRepository.Read(deviceId);

                if (device.Status == StatusType.Disarmed) throw new Exception("La alarma no puede ser desactivada.");

                if (device.Status == StatusType.Tracking)
                {
                    UnitOfWork.LocationRepository.Delete(loc => loc.DeviceId.Equals(device.Id));
                }

                device.Status = StatusType.Disarmed;

                UnitOfWork.AlarmRepository.Delete(device.Id);

                UnitOfWork.DeviceRepository.Update(device);

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
