using System.ComponentModel.DataAnnotations;

namespace Icaz.com.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string RolName { get; set; }

        public List<User> Users { get; set; }
    }
}
