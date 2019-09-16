using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessProjectServerSide.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

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
