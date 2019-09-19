using System.Collections.Generic;
namespace FitnessProjectServerSide.Models
{
    public class User
    {
        /* public User()
         {
             this.NoGoZones = new HashSet<NoGoZone>();
         }*/
       
        public int id { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }
        public string Name { get; set; }
        
    }
}