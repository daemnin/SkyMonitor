using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMonitor.Model
{
    public class Location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public double Latitude { get; set; }

        public double Longitud { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}