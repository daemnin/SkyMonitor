using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMonitor.Model
{
    public class Alarm
    {
        [Key, ForeignKey("Device")]
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Device Device { get; set; }
    }
}