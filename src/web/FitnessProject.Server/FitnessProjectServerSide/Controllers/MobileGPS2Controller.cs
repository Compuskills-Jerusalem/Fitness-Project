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

        [HttpPost]
        public void RelayMessage(Geolocation PersonsLocation)
        {
            var a = 1;
            GpsSensor gpsSensor = new GpsSensor(PersonsLocation);            
            MessageRelayer relayer = new MessageRelayer();
            relayer.RelayMessage(gpsSensor);
            
        }
    }
}