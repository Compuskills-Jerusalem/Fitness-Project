using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Web.Domain
{
    public class User : IdentityUser
    {
        
        public int UserID { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
        public ICollection<UserSensor> UserSensors { get; set; }
        public ICollection<UserNoGoZone> UserNoGoZones { get; set; }

    }
}