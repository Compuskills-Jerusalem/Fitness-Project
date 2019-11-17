using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.GetLatitudeLongitudeFromAddress
{
    public static class GetLatitudeLongitudeFromAddress
    {
        const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
        public static GeoCoordinate FindLocation(string address)
        {

            const string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            const string url2 = "&key=" + Api + "&sensor = false";
            GeoCoordinate geoCoordinate;
            using (var Result = new WebClient())
            {
                MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result.DownloadString(url + address + url2));

                string status = jsonResult.Status;
                string lad = string.Empty;
                string lon = string.Empty;
                for (int i = 0; i < jsonResult.Results.Length; i++)
                {
                    lad += jsonResult.Results[i].Geometry.Location.Lat;
                    lon += jsonResult.Results[i].Geometry.Location.Lng;
                }
                double ladi = Convert.ToDouble(lad);
                double loni = Convert.ToDouble(lon);
                geoCoordinate = new GeoCoordinate(ladi, loni);
            }
            
            return geoCoordinate;
        }
    }
}
