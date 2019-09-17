using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProjectServerSide.Models;

namespace FitnessProjectServerSide.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
      public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(string name)
        {
            using (FittApp fitt = new FittApp())
            {
                fitt.Users.Add(new User {Name=name});
                fitt.SaveChanges();
            }
            return RedirectToAction("GetAddress","Location");
        }
        [HttpGet]
        public ActionResult Login(string name)
        {   
            return View();
        }
        [HttpPost]
        public ActionResult UserInfo(string name)
        {
            
                return View();
        }
        [HttpPost]
        public void RelayMessage(double Latitude, double Longitude)
        {
            Geolocation PersonsLocation = new Geolocation() { Latitude = Latitude, Longitude = Longitude };
            //GpsSensor gpsSensor = new GpsSensor(PersonsLocation);
           // MessageRelayer relayer = new MessageRelayer();
           // relayer.RelayMessage(gpsSensor);

        }


    }
}
