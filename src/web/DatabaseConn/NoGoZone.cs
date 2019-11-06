using System.Collections.Generic;
namespace DatabaseConn
{
    public class NoGoZone
    {
        public int NoGoZoneID { get; set; }
        public ICollection<UserNoGoZone> NoGoZoneId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}