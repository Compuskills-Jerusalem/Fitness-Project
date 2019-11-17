using System.Collections.Generic;
namespace FitnessProject.Web.Domain
{
    public class UserNoGoZone
    {
        public int UserNoGoZoneID { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int NoGoZoneID { get; set; }
        public virtual NoGoZone NoGoZones { get; set; }


    }
}