using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class UserSensorAlert
    {
        public int UserSensorAlertID { get; set; }
        public virtual UserSensor UserSensor { get; set; }
        public virtual Alert Alert { get; set; }
    }
}