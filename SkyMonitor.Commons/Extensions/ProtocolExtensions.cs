using SkyMonitor.Commons.Entities;
using System;

namespace SkyMonitor.Commons.Extensions
{
    public static class ProtocolExtensions
    {
        private const byte LATITUDE_OFFSET = 0;
        private const byte LONGITUDE_OFFSET = 4;
        private const byte DEVICE_ID_OFFSET = 8;

        public static Packet Parse(this byte[] buffer)
        {
            var packet = new Packet
            {
                Location = new Location
                {
                    Latitude = BitConverter.ToSingle(buffer, LATITUDE_OFFSET),
                    Longitude = BitConverter.ToSingle(buffer, LONGITUDE_OFFSET)
                },
                DeviceId = BitConverter.ToInt32(buffer, DEVICE_ID_OFFSET)
            };

            return packet;
        }
    }
}
