using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json; //added JSON.NET with Nuget
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
namespace FitnessProjectServerSide.Models
{
    public class LocateLadLon : LocationInterface
    {
        public void GetLocation(string Address)
        {
            const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
            string url1 = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url2 = "&key=" + Api + "&sensor=false";
            var Result = new WebClient().DownloadString(url1 + Address + url2);
            MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);
            string status = jsonResult.Status;
            string lat = string.Empty;
            string lad = double.TryParse(jsonResult.Results.);
            string lon = string.Empty;
            if(status=="ok")
            {
                for (int i = 0; i < jsonResult.Results.Length; i++)
                {
                    lad += jsonResult.Results[i].Geometry.Location.Lat;
                    lon += jsonResult.Results[i].Geometry.Location.Lng;
                }
                
                }
        }
    }
}