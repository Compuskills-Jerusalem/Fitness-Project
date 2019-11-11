using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConn
{
    public class NoGoZone
    {
        [Key]
        public int NoGoZoneID { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZonesid { get; set; }    
         public string PlaceName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}