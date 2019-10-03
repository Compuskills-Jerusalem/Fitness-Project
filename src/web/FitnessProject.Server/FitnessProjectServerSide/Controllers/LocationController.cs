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
        [HttpGet]
        public ActionResult UserQuery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserQueryResult(string name,NoGoZone noGo)
        {
           

            }
           
        }

        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLadLon(string address,int id,int id2)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                
               // foreach (var item in fitt.NoGoZones)
              //  {
                 //   if(address!=item.Address)
                   // {
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
                        fitt.NoGoZones.Add(new NoGoZone { Address = address, Laditude = ladi, Longitude = loni });
                /*}
               else
                {
                    fitt.UserNoGoZones.Select(x => x.UserId==id);
                    fitt.UserNoGoZones.Select(x => x.NoGoZoneId == id2);
                    fitt.UserNoGoZones.Add( new UserNoGoZone { UserId = id, NoGoZoneId = id2 });
                }*/
                fitt.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.NoGoZoneId == id);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, NoGoZone noGoZone)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.UserId == id);
                fitt.UserNoGoZones.Remove(model);
                fitt.SaveChanges();
                return RedirectToAction("UserInfo", "Location");
            }
        }


    }   
        }
          
        


