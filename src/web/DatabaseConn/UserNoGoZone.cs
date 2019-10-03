namespace DatabaseConn
{
    public class UserNoGoZone
    {
        public int Id;
        public int UserId { get; set; }
        public virtual User Users { get; set; }
        public int NoGoZoneId { get; set; }
        public virtual NoGoZone NoGoZones { get; set; }
    }
}