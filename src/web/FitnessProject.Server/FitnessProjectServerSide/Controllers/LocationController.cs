using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json; //added JSON.NET with Nuget
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using FitnessProjectServerSide.Models;

namespace FitnessProjectServerSide.Controllers
{
    public class LocationController : Controller
    {
        
        // GET: Location
        public ActionResult Index(int id)
        {
            using (FittApp fit = new FittApp())
            {
                return View(fit.UserNoGoZones.Find(id)); 
            }
                
        }
        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLadLon(string address)
        {
          //  string address = string.Empty;
            const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url2 = "&key=" + Api + "&sensor=false";
            var Result = new WebClient().DownloadString(url + address + url2);

            MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);
            string status = jsonResult.Status;
            string lad = string.Empty;
            string lon = string.Empty;
            if (status == "OK")
            {
                for (int i = 0; i < jsonResult.Results.Length; i++)
                {
                    lad += jsonResult.Results[i].Geometry.Location.Lat;
                      lon+=  jsonResult.Results[i].Geometry.Location.Lng;
                }
                double ladi = Convert.ToDouble(lad);
                double loni = Convert.ToDouble(lon);
                
                using (FittApp fitt = new FittApp())
                {
                  
                        fitt.NoGoZones.Add(new NoGoZone { Address = address, Laditude = ladi, Longitude = loni });
                       
                        // fitt.UserNoGoZones.Add(new )
                        fitt.SaveChanges();    
                }
                    return View();
            }
            else
                return View(status);
        }
    }
}


