using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FitnessProjectServerSide
{
    public class FitnessProjectServerSideContext:DbContext
    {
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSensorAlert> UserSensorAlerts { get; set; }
        public DbSet<UserSensor> UserSensors { get; set; }

        public void GetUsers()
        {
            var a = from user in Users
                    select user;
        }
    }
}