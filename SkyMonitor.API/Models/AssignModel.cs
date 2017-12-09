using System.ComponentModel.DataAnnotations;

namespace SkyMonitor.API.Models
{
    public class AssignModel
    {
        [Required(ErrorMessage = "El Id del dispositivo es requerido")]
        public int DeviceId { get; set; }

        [Required(ErrorMessage = "El número de teléfono del usuario es requerido.")]
        public string Phone { get; set; }
    }
}