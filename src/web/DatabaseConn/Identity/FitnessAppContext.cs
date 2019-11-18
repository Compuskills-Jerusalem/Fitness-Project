using DatabaseConn.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
    public class FitnessAppContext : IdentityDbContext<User>
    {
        public DbSet<NoGoZone> NoGoZones { get; set; }
        public DbSet<AlertType> AlertTypes { get; set; }

        public static FitnessAppContext Create()
        {
            return new FitnessAppContext();
        }
    }

}
