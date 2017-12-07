using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyMonitor.Model
{
    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Range { get; set; }
        
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}