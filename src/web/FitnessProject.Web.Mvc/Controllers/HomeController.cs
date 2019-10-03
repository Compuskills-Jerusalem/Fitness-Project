using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseConn;
using FitnessProject.Web.Mvc.Models;
using FitnessProject.Web.Notifications;
using FitnessProject.Web.Calc;
using Xamarin.Essentials;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index()
        {
            ViewBag.Title = "Home Page";
            return View();
        } 

        [HttpPost]
        public void RelayMessage(double Latitude, double Longitude, string userID)
        {
            Geolocation PersonsLocation = new Geolocation() { Latitude = Latitude, Longitude = Longitude };
            using (var context = new FittAppContext())
            {
              var noGoLocations = from u in context.Users
                                  where u.Name == userID
                                  from noGoZone in u.Userid
                                  select noGoZone.NoGoZones;

                LocationCalc.CalcPlace(noGoLocations.AsEnumerable(), new Location(Latitude, Longitude));
            }
           
        }
        [HttpPost]
        public void SenderID(string Token)
        {
            string PushID = Token;
            //todo: send token to db

        }


    }
}
