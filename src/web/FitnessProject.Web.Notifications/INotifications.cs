using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessProject.Web.Notifications
{
    public interface INotifications
    {
        void Send(MessageData messageData);
    }
}
