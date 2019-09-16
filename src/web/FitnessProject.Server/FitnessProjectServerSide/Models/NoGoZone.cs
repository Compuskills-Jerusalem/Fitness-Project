using System.Collections.Generic;
namespace FitnessProjectServerSide.Models
{
    public class NoGoZone
    {
        public int id { get; set; }
        public ICollection<UserNoGoZone> userNos { get; set; }
        public string Address { get; set; }
        public double Laditude { get; set; }
        public double Longitude { get; set; }
    }
}
