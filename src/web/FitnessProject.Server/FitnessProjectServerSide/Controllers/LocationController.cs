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
        const string Api = "AIzaSyCRQ2A5WO3oLqDrjyQhx6BRmf5KSgoo950";
        string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        string url2 = "&key=" + Api + "&sensor=false";
        // GET: Location
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Login(int id, NoGoZone noGoZone)
        {
            using (FittAppContext fitt = new FittAppContext())
            {

                if (ModelState.IsValid)
                {
                    var model = fitt.UserNoGoZones.FirstOrDefault(x => x.NoGoZoneId == id);
                    {
                        model.NoGoZone.Address = noGoZone.Address;
                        var Result = new WebClient().DownloadString(url + noGoZone + url2);
                        MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);
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
                        }

                    }
                    fitt.SaveChanges();
                }
                return RedirectToAction("List");
        }
        }
        [HttpGet]
        public ActionResult List(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.UserId == id).NoGoZone.Address;
                return RedirectToAction("List",model);
            }
        }
        [HttpPost]
        public ActionResult PostList(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.UserId == id).NoGoZone.Address;
                return RedirectToAction("List");
            }
        }

    }
}
