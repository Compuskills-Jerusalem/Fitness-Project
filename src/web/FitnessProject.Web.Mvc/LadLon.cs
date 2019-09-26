using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProjectServerSide
{
    public class LadLon:ILocation
    {
        public void FindLocation(string address)
        {
            const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url2 = "&key=" + Api + "&sensor=false";
        }
    }
}