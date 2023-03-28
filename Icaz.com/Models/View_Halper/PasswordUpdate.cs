using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Icaz.com.Models.View_Halper
{
    public class PasswordUpdate
    {
        public string OldPassword { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$", ErrorMessage ="şifre büyük harf,küçük harf ve en az bir rakam içermelidir")]
        public string NewPassword { get; set; }
    }
}
