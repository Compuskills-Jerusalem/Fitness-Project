using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json; 
using System.Net;
using DatabaseConn;
using FitnessProject.Web.Mvc;
using FitnessProject.Web.Mvc.Models;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class LocationController : Controller
    {
        List<NoGoZone> noGos = null;

        // GET: Location
        public ActionResult Index()
        {
            using (var fitt = new FittAppContext())
            {
                noGos = fitt.NoGoZones.ToList();
            }
            return View(noGos);
        }




        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLadLon(string address)
        {
            FindLocationWithGoogleApiModel googleApiModel = new FindLocationWithGoogleApiModel();
            googleApiModel.FindLocation(address);
            return View();
        }
          
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.NoGoZoneId== id);
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