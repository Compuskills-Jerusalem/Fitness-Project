using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FitnessProject.Web.Mvc.Models
{
    public class FittAppContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NoGoZone> NoGoZones { get; set; }
       public DbSet<UserNoGoZone> UserNoGoZones { get; set; }
    }
}
