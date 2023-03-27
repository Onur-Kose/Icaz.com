using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Icaz.com.Models
{
    public class Konu
    {
        [Key]
        public int KonuId { get; set; }
        public string KonuAdi { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; } = DateTime.Now.Date;



        //Bağlantılar
        [ForeignKey("MemberId")]
        public string MemberId { get; set; }
        public Member Member { get; set; }
        public List<Makale> Makales { get; set; }
        public List<KonuUser> KonuUsers { get; set; }
    }
}
