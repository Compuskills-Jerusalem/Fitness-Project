using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConn
{
    public class User
    {
        
        public int UserID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
        public ICollection<UserSensor> UserSensors { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }

    }
}