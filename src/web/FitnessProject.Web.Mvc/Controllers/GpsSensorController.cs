using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessProject.Web.Mvc;
using FitnessProject.Web.Domain;
using FitnessProject.Web.Notifications;

using System.Device.Location;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class GpsSensorController : Controller
    {
        private FitnessAppContext db = new FitnessAppContext();

        [HttpPost]
        public void RelayMessage(double latitude, double longitude, string emailAddress)
        {
            User TempUser = db.Users.Where(x => x.Email == emailAddress).FirstOrDefault();
            GeoCoordinate PersonLocation = new GeoCoordinate(latitude, longitude);
            var locations = db.NoGoZones.Where(x => x.User.Id==TempUser.Id);

            if (CompareLocations.CompareLocations.Compare(PersonLocation, locations.AsEnumerable()))
            {
                var msgData = new MessageData
                {
                    EMail = TempUser.Email,
                    TelNr = TempUser.TelNr,
                    MsgBody = "You got too close to a no go zone!",
                    MsgHeader = "Alert"
                };

                if (!string.IsNullOrEmpty(TempUser.TelNr))
                {
                    INotifications notification = new SMSNotification();
                    notification.Send(msgData);
                }

                if (!string.IsNullOrEmpty(TempUser.Email))
                {
                    INotifications notification = new EMailNotification();
                    notification.Send(msgData);
                }
                if (!string.IsNullOrEmpty(TempUser.Push))
                {
                    INotifications notification = new PushFirebase();
                    notification.Send(msgData);
                }
            }
        }
        public void FirebaseToken(string email, string token)
        {
            User TempUser = db.Users.Where(x => x.Email == email).FirstOrDefault();
            if (TempUser!=null)
            {
                TempUser.Push = token;
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}