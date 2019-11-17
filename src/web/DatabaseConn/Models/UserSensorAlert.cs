using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
   public class UserSensorAlert
    {
        public int UserSensorAlertID { get; set; }

        public int UserSensorID { get; set; }
        public virtual UserSensor UserSensor { get; set; }

        public int AlertID { get; set; }
        public virtual Alert Alert { get; set; }
    }
}
