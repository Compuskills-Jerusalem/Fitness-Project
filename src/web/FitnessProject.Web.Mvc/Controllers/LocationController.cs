using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json; 
using System.Net;
using DatabaseConn;
using FitnessProject.Web.Mvc;
using FitnessProject.Web.Mvc.Models;

namespace FitnessProjectServerSide.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        List<NoGoZone> noGos = null;

        // GET: Location
        public ActionResult Index()
        {
            using (var fitt = new FittAppContext())
            {
                noGos = fitt.NoGoZones.ToList();
            }
            return View(noGos);
        }
        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAddress (string address)
        {
            
            FindLocationWithGoogleApiModel googleApiModel = new FindLocationWithGoogleApiModel();
            googleApiModel.FindLocation(address, User.Identity.Name); 
            googleApiModel.AddToJoinTable(address, User.Identity.Name);
            return RedirectToAction("UserInfo", "User");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var mode1 = fitt.UserNoGoZones.SingleOrDefault(x => x.NoGoZoneId == id);
                return View(mode1);
            }
            
        }
        [HttpPost]
        public ActionResult Delete(int id,UserInfoModel userInfoModel)
        {
            using (FittAppContext fitt = new FittAppContext())
            {

                var model = fitt.UserNoGoZones.SingleOrDefault(x => x.NoGoZoneId == userInfoModel.Id);
                fitt.UserNoGoZones.Remove(model);

            }
              
                return RedirectToAction("UserInfo", "User");
            }
        }
    }
