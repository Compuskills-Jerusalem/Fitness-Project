using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
    public class FittAppContext : IdentityDbContext<User>
    {
        public DbSet<NoGoZone> NoGoZones { get; set; }
        public DbSet<UserNoGoZone> UserNoGoZones { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<UserSensor> UserSensors { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserSensorAlert> UserSensorAlerts { get; set; }
    }

}
