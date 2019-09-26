using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessProject.Web.Notifications
{
    interface INotifications
    {
        void Send(MessageData messageData);
    }
}
