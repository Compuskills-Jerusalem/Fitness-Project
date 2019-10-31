using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConn
{
    public class NoGoZones
    {
        [Key]
        public int NoGoZoneID { get; set; }
        public ICollection<UserNoGoZone> NoGoZoneId { get; set; }
        public string Address { get; set; }
        public double Laditude { get; set; }
        public double Longitude { get; set; }
    }
}