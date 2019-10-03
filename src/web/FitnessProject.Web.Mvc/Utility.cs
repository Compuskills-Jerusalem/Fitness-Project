using DatabaseConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FitnessProject.Web.Mvc
{
    public class Utility
    {
     public void AddUserToJoin(string name)
        {
            using (var fitt = new FittAppContext())
            {            
                var model = from noGo in fitt.UserNoGoZones
                            where noGo.Users.Name == name
                            select new UserNoGoZone
                            {
                                UserId = noGo.UserId,
                            };
                fitt.SaveChanges();
            }
        }
        public void AddDangerZoneToJoin(string address)
        {
            using (var fitt = new FittAppContext())
            {
              
                var model = from noGo in fitt.UserNoGoZones
                            where noGo.NoGoZones.Address==address
                            select new UserNoGoZone
                            {
                                NoGoZoneId = noGo.NoGoZoneId
                            };
                fitt.SaveChanges();
            }
        }
    }
}