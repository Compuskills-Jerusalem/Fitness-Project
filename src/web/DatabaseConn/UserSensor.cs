using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn
{
   public class UserSensor
    {
        public int UserSensorID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int SensorID { get; set; }
        public virtual Sensor Sensor { get; set; }
        public ICollection<UserSensorAlert> UserSensorAlerts { get; set; }
    }
}
