using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessProject.Web.Mvc;
using DatabaseConn;
using FitnessProject.Web.Notifications;

using System.Device.Location;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class GpsSensorController : Controller
    {
        public MessageTargetList GpsSensorTargetList(string emailAddress)
        {
            using (FittAppContext FAC = new FittAppContext())
            {
                var userID = (from user in FAC.Users
                              where user.EMail == emailAddress
                              select user.UserID ).Single();

                var userSensorID = (from userSensor in FAC.UserSensors
                                    where userSensor.UserID == userID && userSensor.Sensor.SensorName == "GpsSensor"
                                    select userSensor.UserSensorID).Single();

                var targetListItems = from userSensorAlert in FAC.UserSensorAlerts
                                      where userSensorAlert.UserSensorID == userSensorID
                                      select userSensorAlert.UserSensorAlertID;

                MessageTargetList List = new MessageTargetList();
                foreach (var TargetListItem in targetListItems)
                {
                    if (TargetListItem == 1)
                    {
                        MessageData messageData = new MessageData();
                        EMailNotification eMailNotification = new EMailNotification();
                        List.MessageTypeTargetList.Add(eMailNotification);
                    }
                }

                return List;
            }

        }

        public IQueryable<NoGoZone> GetNoGoZonesByEmail(string EmailAddress)
        {
            using (FittAppContext FAC = new FittAppContext())
            {
                var noGoZones = from userNoGoZone in FAC.UserNoGoZones
                                where userNoGoZone.User.EMail == EmailAddress
                                select userNoGoZone.NoGoZones;

                return noGoZones.ToList().AsQueryable();
            }
        }


        //what you have to do above is to get the EmailAddress string query the corresponding users ID and then query all of his Alerts for Gps
        //then translate that to a message target list somehow 
        //then your going to have to provide that to the message relayer in the relay action method
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public void RelayMessage(double latitude, double longitude, string emailAddress, string phoneNumber)
        {
            GeoCoordinate PersonLocation = new GeoCoordinate(latitude, longitude);
            GpsSensor gpsSensor = new GpsSensor(PersonLocation, GetNoGoZonesByEmail(emailAddress));

            if (gpsSensor.ShouldAlertUser())
            {
                var msgData = new MessageData
                {
                    EMail = emailAddress,
                    TelNr = phoneNumber,
                    MsgBody = "You got too close to a no go zone!",
                    MsgHeader = "Alert"
                };

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    INotifications notification = new SMSNotification();
                    notification.Send(msgData);
                }

                if (!string.IsNullOrEmpty(emailAddress))
                {
                    INotifications notification = new EMailNotification();
                    notification.Send(msgData);
                }
            }
        }

        [HttpGet]
        public void Mock()
        {


        }
    }
}