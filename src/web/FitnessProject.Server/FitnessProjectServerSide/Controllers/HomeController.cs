using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProjectServerSide.Models;
using Notifications;

namespace FitnessProjectServerSide.Controllers
{
    public class HomeController : Controller
    { public ActionResult Home()
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
            using (FittAppContext fitt = new FittAppContext())
            {
                
                fitt.Users.Add(new User {Name=name});
                fitt.SaveChanges();
            }
            return RedirectToAction("GetAddress","Location");
        }
        [HttpGet]
        public ActionResult Login(int id,int noGoid)
        {
         
                return View();
        }
        [HttpGet]
        public ActionResult UserInfo()
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var a = fitt.UserNoGoZones.Take(4).Include(x => x.User).Select(y => y.NoGoZone);
                foreach (var item in a)
                {
                    var B = item.UserNoGoZones.AsEnumerable();
                    return View(B);
                }
            }
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
