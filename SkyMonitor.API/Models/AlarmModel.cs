using System.ComponentModel.DataAnnotations;

namespace SkyMonitor.API.Models
{
    public class AlarmModel
    {
        [Required(ErrorMessage = "El Id del dispositivo es requerido.")]
        public int DeviceId { get; set; }
    }
}