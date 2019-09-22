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
using System.Data.Entity;

namespace FitnessProjectServerSide.Controllers
{
    public class LocationController : Controller
    {
        List<NoGoZone> noGos = null;
        const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
        string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        string url2 = "&key=" + Api + "&sensor=false";
        // GET: Location
        public ActionResult Index()
        {
            using (var fitt=new FittAppContext())
            {
                noGos = fitt.NoGoZones.ToList();
            }
            return View(noGos);
             
        }
        public ActionResult Details(int id)
        {
            using (var fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.NoGoZoneId == id);
              
                return View(model);
            }
             
        }
        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLadLon(string address, string address2)
        {
            //  string address = string.Empty;

            var Result = new WebClient().DownloadString(url + address + url2);
            var Result2 = new WebClient().DownloadString(url + address2 + url2);
            MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);
            MapsApiResponse jsonResult2 = JsonConvert.DeserializeObject<MapsApiResponse>(Result2);
            string status = jsonResult.Status;
            string lad = string.Empty;
            string lon = string.Empty;
            if (status == "OK")
            {
                for (int i = 0; i < jsonResult.Results.Length; i++)
                {
                    lad += jsonResult.Results[i].Geometry.Location.Lat;
                    lon += jsonResult.Results[i].Geometry.Location.Lng;
                }
                double ladi = Convert.ToDouble(lad);
                double loni = Convert.ToDouble(lon);

                using (FittAppContext fitt = new FittAppContext())
                {
                    if (ModelState.IsValid)
                    {
                        fitt.NoGoZones.Add(new NoGoZone { Address = address, Laditude = ladi, Longitude = loni });
                        fitt.NoGoZones.Add(new NoGoZone { Address = address2, Laditude = ladi, Longitude = loni });
                    }
                    // var h = fitt.NoGoZones.Select(x => x.id).Max() + 1;
                    fitt.SaveChanges();
                }
            }
            else
            {
                return View(status);
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.NoGoZoneId == id);
                return View(model);
            }
        }
        
        [HttpPost]
        public ActionResult List(int id,NoGoZone noGoZone)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
               var model = fitt.UserNoGoZones.FirstOrDefault(x => x.UserId == id);
                model.UserNoGoZones.Address = noGoZone.Address;
                return  View (model);
            }
        }
      

    }
}
