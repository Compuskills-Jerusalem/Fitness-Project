using FitnessProject.Web.Mvc.Interfaces;

namespace FitnessProject.Web.Mvc
{
    public class GpsSensor : ISensor
    {
        public int SensorID { get; set; }

        public bool ShouldAlertUser()
        {
            return true;
        }

        public GpsSensor(Geolocation PersonsLocation )
        {

        }
    }
}