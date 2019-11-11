using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.Web.Mvc.Services
{
    public class DistanceCalculator
    {
        public double degreestoRadius(double degrees)
        {
            return degrees * (Math.PI * 180);
        }
        public double ComputeDistance(double lad1, double lon1, double lad2, double lon2, string userName)
        {
            //    const string url1 = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=";
            //   const string url2 = "&key=" + Api;
            // var here = new WebClient().DownloadString(url1 + location + url2);
            var radius = 6371;
            var distanceInlad = degreestoRadius(lad2 - lad1);
            var distanceInLon = degreestoRadius(lon2 - lon1);
            double a = Math.Sin(distanceInlad / 2) * Math.Sin(distanceInlad / 2) +
                Math.Cos(degreestoRadius(lad1)) * Math.Cos(degreestoRadius(lad2)) *
                Math.Sin(distanceInLon / 2) * Math.Sin(distanceInLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = radius * c;
            return d;
             }
    }
}