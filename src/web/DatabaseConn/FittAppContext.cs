using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn
{
    public class FittAppContext:DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<NoGoZone> NoGoZones { get; set; }
        public DbSet<UserNoGoZone> UserNoGoZones { get; set; }
    }

}
