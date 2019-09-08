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
            MockImessageclass m = new MockImessageclass();
            MessageTypeTargetList.Add(m);
        }
        public List<IMessage> MessageTypeTargetList = new List<IMessage>();
        

    }
}
