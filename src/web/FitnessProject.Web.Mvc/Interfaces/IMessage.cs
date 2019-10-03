namespace FitnessProject.Web.Mvc.Interfaces
{
    public interface IAlert
    {
        int AlertID { get; set; }
        void SendAlert();
    }
}
