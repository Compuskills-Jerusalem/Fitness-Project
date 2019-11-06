using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FitnessProjectServerSide.Controllers
{
    public class GpsSensorController : Controller
    {
       

      
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public void RelayMessage(Geolocation PersonsLocation, string EmailAddress)
        {

            GpsSensor gpsSensor = new GpsSensor(PersonsLocation);
            MessageRelayer relayer = new MessageRelayer();
            relayer.RelayMessage(gpsSensor);

        }
       
    } 
}