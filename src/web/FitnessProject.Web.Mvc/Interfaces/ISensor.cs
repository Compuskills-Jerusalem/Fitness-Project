namespace FitnessProject.Web.Mvc.Interfaces
{
    public interface ISensor
    {
        int SensorID { get; set; }
        bool ShouldAlertUser();
    }
}
