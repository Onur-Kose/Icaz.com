using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Icaz.com.Enums;
using Icaz.com.Validation;

namespace Icaz.com.Models
{
    public class User 
    {
        public User()
        {
            KullaniciURL = UserId.ToString() + Ad + Soyad;
        }
        [Key]
        public int UserId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [Cinsiyet_Validation]
        public string Cinsiyet { get; set; }
        [Birthdate_Validation]
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string Kullaniciadi { get; set; }
        [EmailAddress]
        public string EmailAdresi { get; set; }

        public string KullaniciURL { get; set; }
        public bool DeleteUser { get; set; } = false;
        
        public string Sifre { get; set; }

        //Bağlantılar
        [ForeignKey("RolId")]
        public int RolId { get; set; } = 1;
        public Rol Rol { get; set; }


        public List<Konu> Konular { get; set; }
        public List<Makale> Makaleler { get; set; }




    }
}
