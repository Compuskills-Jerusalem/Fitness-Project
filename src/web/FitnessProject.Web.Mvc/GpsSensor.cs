//using FitnessProject.Web.Domain;
//using FitnessProject.Web.Mvc.Interfaces;
//using System.Linq;
//using System.Device;
//using System.Device.Location;
//using System.Collections.Generic;
//using Newtonsoft.Json.Linq;

//namespace FitnessProject.Web.Mvc
//{
//    public class GpsSensor : ISensor
//    {
//        const double THRESHOLD = 0.1;

//        public int SensorID { get; set; }
//        public bool DistanceIsLessThanThreshold { get; set; }

//        public bool ShouldAlertUser()
//        {
//            return DistanceIsLessThanThreshold;
//        }

//        public GpsSensor(GeoCoordinate personsLocation, IQueryable<NoGoZone> noGoZones)
//        {
//            //public static void CalcPlace(IEnumerable<NoGoZone> NoGoUsers, Location User)
//            //{sh


//            foreach (var noGoZoneItem in noGoZones)
//            {
//                GeoCoordinate DZone = new GeoCoordinate(noGoZoneItem.Latitude, noGoZoneItem.Longitude);


//                double distance = DZone.GetDistanceTo(personsLocation);

//                if (distance < THRESHOLD)
//                {
//                    DistanceIsLessThanThreshold = true;

//                }
//                else
//                {
//                    DistanceIsLessThanThreshold = false;
//                }


//            }
//        }
//    }
//}
