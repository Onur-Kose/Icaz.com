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
        [ForeignKey("MemberId")]
        public string? MemberId { get; set; }
        public Member Member { get; set; }

        
    }
}
