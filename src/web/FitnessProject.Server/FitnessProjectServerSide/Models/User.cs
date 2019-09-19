using System.Collections.Generic;
namespace FitnessProjectServerSide.Models
{
    public class User
    {
        public int id { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }
        public string Name { get; set; }
    }
}
