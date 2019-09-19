namespace FitnessProjectServerSide.Models
{
    public class UserNoGoZone
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public virtual User users { get; set; }
        public int NoGoZoneId { get; set; }
        public virtual NoGoZone UserNoGoZones { get; set; }
    }
}
