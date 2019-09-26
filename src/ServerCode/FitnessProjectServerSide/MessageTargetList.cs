using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProjectServerSide
{
    public class MessageTargetList
    {

        public MessageTargetList()
        {
            using (FitnessProjectServerSideContext Cntxt = new FitnessProjectServerSideContext())
            {
                var a = from userSensor in Cntxt.UserSensors
                        where userSensor.UserSensorID == 1 && userSensor.User.UserID == 3
                        select userSensor.UserSensorAlerts;
                foreach (var item in a)
                {
                    if (item== this.)
                }
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
