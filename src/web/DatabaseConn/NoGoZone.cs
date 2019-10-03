using System.Collections.Generic;
namespace DatabaseConn
{
    public class NoGoZone
    {
        public int Id { get; set; }
        public ICollection<UserNoGoZone> NoGoZoneId { get; set; }
        public string Address { get; set; }
        public double Laditude { get; set; }
        public double Longitude { get; set; }
    }
}