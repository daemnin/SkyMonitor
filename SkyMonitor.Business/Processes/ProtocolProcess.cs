using SkyMonitor.Business.Helpers;
using SkyMonitor.Commons.Entities;
using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using Location = SkyMonitor.Model.Location;

namespace SkyMonitor.Business.Processes
{
    public class ProtocolProcess : ProcessBase
    {
        public ProtocolProcess(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Orchestrate(Packet packet)
        {
            try
            {
                var device = UnitOfWork.DeviceRepository.Read(packet.DeviceId);

                if (device == null) return;

                device.Latitude = packet.Location.Latitude;

                device.Longitude = packet.Location.Longitude;

                UnitOfWork.DeviceRepository.Update(device);

                UnitOfWork.Save();

                switch (device.Status)
                {
                    case StatusType.Armed:
                    case StatusType.Warning:
                        CheckBoundaries(device);
                        break;
                    case StatusType.Tracking:
                        SaveHistory(device);
                        break;
                }
            }
            catch { }
        }

        private void SaveHistory(Device device)
        {
            var location = new Location
            {
                DeviceId = device.Id,
                Latitude = device.Latitude,
                Longitud = device.Longitude
            };

            UnitOfWork.LocationRepository.Create(location);

            UnitOfWork.Save();
        }

        private void CheckBoundaries(Device device)
        {
            var alarm = UnitOfWork.AlarmRepository.Read(device.Id);

            var outOfRange = DistanceHelper.Instance.Calculate(device.Latitude, device.Longitude, alarm.Latitude, alarm.Longitude) > device.Range;

            var updateStatus = outOfRange;

            if (outOfRange)
            {
                if (device.Status == StatusType.Warning)
                {
                    WarningOwner();

                    device.Status = StatusType.Tracking;
                }
                else
                {
                    device.Status = StatusType.Warning;
                }
            }
            else if (device.Status == StatusType.Warning)
            {
                device.Status = StatusType.Armed;
                updateStatus = true;
            }

            if (updateStatus)
            {
                UnitOfWork.DeviceRepository.Update(device);

                UnitOfWork.Save();
            }
        }

        private void WarningOwner()
        {
            //TODO: avisar al dueño
        }
    }
}