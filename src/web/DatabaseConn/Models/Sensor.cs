using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
   public class Sensor
    {
        public int SensorID { get; set; }
        public string SensorName { get; set; }
        public ICollection<UserSensor> UserSensors { get; set; }
    }
}
