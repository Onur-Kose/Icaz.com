using System.ComponentModel.DataAnnotations;

namespace Icaz.com.Models.View_Halper
{
    public class LoginUser
    {
        [EmailAddress(ErrorMessage ="e posta adresi epposat şeklinde olmalıdır.")]
        public string Eposta { get; set; }
        public string Password { get; set; }
    }
}
