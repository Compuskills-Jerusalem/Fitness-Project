using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessProjectServerSide
{
    public class MessageData
    {
        public string PushID { get; set; }
        public string EMail { get; set; }
        private string _TelNr;

        public string TelNr
        {
            get { return _TelNr; }
            set {
                if (value[0]=='0')
                {
                    if (value[1]=='0')
                    {
                        _TelNr=value.Substring(2);
                    }
                    else
                    {
                        _TelNr = value.Substring(1);
                    }
                }
                else { _TelNr = value; }
               
            }
        }

        public string MsgHeader { get; set; }
        public string MsgBody { get; set; }
    }
}
