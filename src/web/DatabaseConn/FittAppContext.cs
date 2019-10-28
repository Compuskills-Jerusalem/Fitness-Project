using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn
{
    public class FittAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
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
