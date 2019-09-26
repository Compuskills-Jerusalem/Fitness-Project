using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessProjectServerSide
{
    public class Alert
    {
        public int AlertID { get; set; }
        public string AlertName { get; set; }
        public ICollection<UserSensorAlert> UserSensorAlerts { get; set; }
    }
}