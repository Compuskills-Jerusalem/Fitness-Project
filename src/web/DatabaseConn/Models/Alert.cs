using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.Web.Domain
{
    public class Alert
    {
        public int AlertID { get; set; }
        public string AlertName { get; set; }
        public ICollection<UserSensorAlert> UserSensorAlerts { get; set; }
    }
}
