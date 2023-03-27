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
        public int Puan { get; set; } = 0;
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; } = DateTime.Now.Date;
        [DataType(DataType.Date)]
        public DateTime EditTime { get; set; }

        public virtual int KonuId { get; set; }
        //Bağlantılar
        [ForeignKey("MemberId")]
        public string? MemberId { get; set; }
        public Member Member { get; set; }

        
    }
}
