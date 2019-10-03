using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProjectServerSide
{
    public class MessageRelayer
    {
        public void RelayMessage(ISensor SensorType)
        {
            
            if (SensorType.ShouldAlertUser() == true)
            {
                MessageTargetList GivenList = new MessageTargetList();
                foreach (var MessageType in GivenList.MessageTypeTargetList)
                {

                    MessageType.SendAlert();
                }
            }
        }

    }
}