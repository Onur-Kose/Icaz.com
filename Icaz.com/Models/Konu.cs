using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Icaz.com.Models
{
    public class Konu
    {
        [Key]
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }
        public DateTime CreateTime { get; set; }



        //Bağlantılar
        [ForeignKey("MemberId")]
        public string MemberId { get; set; }
        public Member Member { get; set; }
        public List<Makale> Makales { get; set; }
    }
}
