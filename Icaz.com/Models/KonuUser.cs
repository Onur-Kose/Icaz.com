namespace Icaz.com.Models
{
    public class KonuUser
    {
        public int KonuUserId { get; set; }
        public List<Konu> Konus { get; set; }
        public List<Member> Members { get; set; }
    }
}
