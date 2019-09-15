using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json; //added JSON.NET with Nuget
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
namespace FitnessProjectServerSide.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InputAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLadLon(string Address)
        {

            const string Api = "Your Api Key";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url2 = "&key=" + Api + "&sensor=false";
            var Result = new WebClient().DownloadString(url + Address + url2);
            MapsApiResponse jsonResult = JsonConvert.DeserializeObject<MapsApiResponse>(Result);
            string status = jsonResult.Status;
            string location = string.Empty;
            if (status == "OK")
            {
                for (int i = 0; i < jsonResult.Results.Length; i++)
                {
                    location += "Latitude" + jsonResult.Results[i].Geometry.Location.Lat +
                         "/Longitude" + jsonResult.Results[i].Geometry.Location.Lng;
                }

                return View((object)location);
            }
            else
                return View(status);
        }
    }
}


