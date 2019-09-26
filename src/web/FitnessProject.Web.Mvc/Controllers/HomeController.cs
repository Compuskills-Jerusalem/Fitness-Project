using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProject.Web.Mvc.Models;
using FitnessProject.Web.Notifications;

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
        public void RelayMessage(double Latitude, double Longitude)
        {
            Geolocation PersonsLocation = new Geolocation() { Latitude = Latitude, Longitude = Longitude };
            //GpsSensor gpsSensor = new GpsSensor(PersonsLocation);
            // MessageRelayer relayer = new MessageRelayer();
            // relayer.RelayMessage(gpsSensor);
            
            EMailNotification n = new EMailNotification();
            MessageData messageData = new MessageData()
            {
                EMail = "ykosbie@compuskills.org",
                MsgBody = string.Format("The Latitude is {0} and the Longitude is {1}.", PersonsLocation.Latitude, PersonsLocation.Longitude),
                MsgHeader = "Test is Working",
                TelNr = "972586846003"
            };
            n.Send(messageData);
            SMSNotification s = new SMSNotification();
            s.Send(messageData);
            
        }
        [HttpPost]
        public void SenderID(string Token)
        {
            string PushID = Token;
            //todo: send token to db

        }


    }
}
