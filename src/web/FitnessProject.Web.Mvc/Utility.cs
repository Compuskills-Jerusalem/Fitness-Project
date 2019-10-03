using DatabaseConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FitnessProjectServerSide
{
    public class Utility
    {
    
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