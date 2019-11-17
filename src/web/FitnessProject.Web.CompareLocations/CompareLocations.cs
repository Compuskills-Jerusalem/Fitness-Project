using FitnessProject.Web.Domain;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.CompareLocations
{
    public static class CompareLocations
    {
        public static bool Compare(GeoCoordinate personLocation, IEnumerable<NoGoZone> UserNoGoList)
        {
            foreach (var NoGo in UserNoGoList)
            {
                if (personLocation.GetDistanceTo(new GeoCoordinate(NoGo.Latitude,NoGo.Longitude))<100)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
