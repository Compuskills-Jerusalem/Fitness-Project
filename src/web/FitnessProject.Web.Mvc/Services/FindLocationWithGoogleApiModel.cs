using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DatabaseConn;
using Newtonsoft.Json;

namespace FitnessProject.Web.Mvc.Models
{
    public class FindLocationWithGoogleApiModel : ILocation
    {
        const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
        public void FindLocation(string address,string placeName, string username)
        {

                const string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            const string url2 = "&key=" + Api + "&sensor = false";
           
                var Result = new WebClient().DownloadString(url + address + url2);
            MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);

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
            using (FittAppContext fitt = new FittAppContext())
            {

                fitt.NoGoZones.Add(new NoGoZone { Address = address, Latitude = ladi, Longitude = loni,PlaceName=placeName });
                    fitt.SaveChanges();
                  
                }
            }           
    
      
   
    
        }
  

    }
 
