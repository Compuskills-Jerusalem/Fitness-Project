using DatabaseConn;
using FitnessProject.Web.Mvc.Interfaces;
using System.Linq;
using Xamarin.Essentials;

namespace FitnessProject.Web.Mvc
{
    public class GpsSensor : ISensor
    {
        const double THRESHOLD = 0.1;

        public int SensorID { get; set; }
        public bool DistanceIsLessThanThreshold { get; set; }

        public bool ShouldAlertUser()
        {
            return DistanceIsLessThanThreshold;
        }

        public GpsSensor(Location personsLocation, IQueryable<NoGoZone> noGoZones)
        {
            //public static void CalcPlace(IEnumerable<NoGoZone> NoGoUsers, Location User)
            //{sh

            foreach (var noGoZoneItem in noGoZones)
            {
                Location DZone = new Location(noGoZoneItem.Latitude, noGoZoneItem.Longitude);
                var distance = Location.CalculateDistance(personsLocation, DZone, DistanceUnits.Kilometers);
                if (distance < THRESHOLD)
                {
                    DistanceIsLessThanThreshold = true;

                }
                else
                {
                    DistanceIsLessThanThreshold = false;
                }


            }
        }
    }
}
