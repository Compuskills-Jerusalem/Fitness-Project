using FitnessProject.Web.Mvc.Interfaces;

namespace FitnessProject.Web.Mvc
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