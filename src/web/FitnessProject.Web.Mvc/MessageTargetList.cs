using DatabaseConn;
using FitnessProject.Web.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.Web.Mvc
{
    public class MessageTargetList
    {
        public MessageTargetList()
        {
            using (FittAppContext cntxt = new FittAppContext())
            {
                //var a = from userSensor in cntxt.UserSensors
                //        where userSensor.UserSensorID == 1 && userSensor.User.UserID == 3
                //        select userSensor.UserSensorAlerts;

                //foreach (var item in a)
                //{
                //    if (item== this.)
                //}
            }
        }
        public List<IAlert> MessageTypeTargetList = new List<IAlert>();

        public List<int> AlertsForUserSensor()
        {

            return null;
        }
        public List<IAlert> TranslateToIMessageTypes()
        {
            return null;
        }

    }
}
