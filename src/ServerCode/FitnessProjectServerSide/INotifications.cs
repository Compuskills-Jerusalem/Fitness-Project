using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessProjectServerSide
{
    interface INotifications
    {
        void Send(MessageData messageData);
    }
}
