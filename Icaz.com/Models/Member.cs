using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Icaz.com.Enums;
using Icaz.com.Validation;
using Microsoft.AspNetCore.Identity;

namespace Icaz.com.Models
{
    public class Member : IdentityUser
    {
        public Member()
        {
            Guid elma = new Guid();
            KullaniciURL =  Ad + Soyad + elma ;
        }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        [Cinsiyet_Validation]
        public string Cinsiyet { get; set; }
        [Birthdate_Validation]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        
        public string KullaniciURL { get; set; }
        public bool DeleteUser { get; set; } = false;


        public List<Konu> Konular { get; set; }
        public List<Makale> Makaleler { get; set; }




    }
}
