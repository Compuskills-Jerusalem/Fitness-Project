using DatabaseConn;
using FitnessProject.Web.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessProject.Web.Notifications;

namespace FitnessProject.Web.Mvc
{
    public class MessageTargetList
    {
        
        public List<INotifications> MessageTypeTargetList = new List<INotifications>();

       

    }
}
