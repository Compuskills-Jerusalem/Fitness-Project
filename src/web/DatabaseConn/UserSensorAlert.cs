using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn
{
   public class UserSensorAlert
    {
        public int UserSensorAlertID { get; set; }
        public virtual UserSensor UserSensor { get; set; }
        public virtual Alert Alert { get; set; }
    }
}
