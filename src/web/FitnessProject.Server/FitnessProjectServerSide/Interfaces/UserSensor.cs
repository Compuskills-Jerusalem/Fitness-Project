using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class UserSensor
    {
        public int UserSensorID { get; set; }
        public virtual User User { get; set; }
        public virtual Sensor Sensor { get; set; }
        public ICollection<UserSensorAlert> UserSensorAlerts { get; set; }
    }
}