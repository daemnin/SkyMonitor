using System.ComponentModel.DataAnnotations;

namespace SkyMonitor.API.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido"),
        Phone(ErrorMessage = "Número de teléfono inváido")]
        public string Phone { get; set; }
    }
}