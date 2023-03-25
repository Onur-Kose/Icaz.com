using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Icaz.com.Models
{
    public class Makale
    {
        [Key]
        public int MakaleId { get; set; }
        public string MakleAdi { get; set; }
        public string MakleOzet { get; set; }
        public string MakleMetni { get; set; }
        public int KacOkundu { get; set; }
        public int Puan { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EditTime { get; set; }

        public virtual int KonuId { get; set; }
        //Bağlantılar
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }

        
    }
}
