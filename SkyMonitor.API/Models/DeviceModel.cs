using System.ComponentModel.DataAnnotations;

namespace SkyMonitor.API.Models
{
    public class DeviceModel
    {
        [Required(ErrorMessage = "El identificador del dispositivo es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del dispositivo es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El rango es requerido.")]
        [Range(15, 50, ErrorMessage = "El rango debe de estar entre 15 y 100 metros.")]
        public int Range { get; set; }
    }
}