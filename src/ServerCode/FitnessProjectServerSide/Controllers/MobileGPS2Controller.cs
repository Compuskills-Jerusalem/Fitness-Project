using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessProjectServerSide.Controllers
{
    public class MobileGPSController : Controller
    {
        // GET: MobileGPS2
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public void RelayMessage(double Latitude, double Longitude)
        {
            Geolocation PersonsLocation = new Geolocation() { Latitude=Latitude, Longitude=Longitude};
            GpsSensor gpsSensor = new GpsSensor(PersonsLocation);            
            MessageRelayer relayer = new MessageRelayer();
            relayer.RelayMessage(gpsSensor);
            
        }
    }
}