using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProjectServerSide
{
    public interface ISensor
    {
        int SensorID { get; set; }
        bool ShouldAlertUser();
    }
}
