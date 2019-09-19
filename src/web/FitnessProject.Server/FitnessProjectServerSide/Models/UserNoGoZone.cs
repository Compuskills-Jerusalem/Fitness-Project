namespace FitnessProjectServerSide.Models
{
    public class UserNoGoZone
    {     
        public int id { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }
        public int NoGoZoneId { get; set; }
        public virtual NoGoZone NoGoZone { get; set; }
    }
}