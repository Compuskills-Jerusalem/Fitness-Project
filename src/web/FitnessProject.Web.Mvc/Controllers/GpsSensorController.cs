using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessProject.Web.Mvc;
using DatabaseConn;
using FitnessProject.Web.Notifications;
using Xamarin.Essentials;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class GpsSensorController : Controller
    {
        public MessageTargetList GpsSensorTargetList(string EmailAddress)
        {
            using (FittAppContext FAC = new FittAppContext())
            {
                var userID = (from UserContact in FAC.UserContacts
                              where UserContact.ContactValue == EmailAddress
                              select new { UserContact.User.UserID }).Single();

                var UserSensorID = (from UserSensor in FAC.UserSensors
                                    where UserSensor.UserID == userID.UserID && UserSensor.Sensor.SensorName == "GpsSensor"
                                    select new { UserSensor.UserSensorID }).Single();

                var TargetListItems = from UserSensorAlert in FAC.UserSensorAlerts
                                      where UserSensorAlert.UserSensorID == UserSensorID.UserSensorID
                                      select UserSensorAlert.UserSensorAlertID;

                MessageTargetList List = new MessageTargetList();
                foreach (var TargetListItem in TargetListItems)
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

        public IQueryable<NoGoZones> GetNoGoZonesByEmail(string EmailAddress)
        {
            using (FittAppContext FAC = new FittAppContext())
            {
                var noGoZones = from userContact in FAC.UserContacts
                                where userContact.ContactValue == EmailAddress
                                from userNoGoZone in userContact.User.UserNoGoZones
                                select userNoGoZone.NoGoZone;

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
        public void RelayMessage(double latitude, double longitude, string emailAddress)
        {

            Xamarin.Essentials.Location PersonsLocation = new Xamarin.Essentials.Location(latitude, longitude);

            MessageTargetList targetList = GpsSensorTargetList(emailAddress);
            GpsSensor gpsSensor = new GpsSensor(PersonsLocation, GetNoGoZonesByEmail(emailAddress));
            bool signal = gpsSensor.ShouldAlertUser();
            if (signal == true)
            {
                foreach (var item in targetList.MessageTypeTargetList)
                {
                    item.Send(new MessageData
                    {
                        EMail = emailAddress,
                        MsgBody = "Success",
                        MsgHeader = "taaaaaaaaaaaaatttttttttiiiiiiiiii",
                        TelNr = "972586846003"

                    });
                }
            }
            //MessageRelayer relayer = new MessageRelayer();
            //relayer.RelayMessage(gpsSensor);

        }
        [HttpGet]
        public void Mock()
        {


        }
    }
}