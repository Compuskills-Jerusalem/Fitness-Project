using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Web.Domain
{
    public class NoGoZone
    {
        [Key]
        public int NoGoZoneID { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}