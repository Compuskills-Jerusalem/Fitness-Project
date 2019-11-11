using System.Collections.Generic;

namespace DatabaseConn
{
    public class LocationName
    {    
        
        public int LocationNameID { get; set; }
        public virtual NoGoZone NoGoZones { get; set; }
       public ICollection<UserNoGoZone> UserNoGoZones { get; set; }
        public string PlaceName { get; set; }
    }
}