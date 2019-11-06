using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json; 
using System.Net;
using DatabaseConn;
using FitnessProject.Web.Mvc;
using FitnessProject.Web.Mvc.Models;
using System.Web.Security;

namespace FitnessProjectServerSide.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        List<NoGoZones> noGos = null;

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
           using(FittAppContext fitt=new FittAppContext())
            {
                if(fitt.NoGoZones.Any(x=>x.Address==address))
                {
                    googleApiModel.AddToJoinTable(address, User.Identity.Name);
                }
                else
                {
                    googleApiModel.FindLocation(address, User.Identity.Name);
                    googleApiModel.AddToJoinTable(address, User.Identity.Name);
                }
            } 
            return RedirectToAction("UserInfo", "User");
        }


        [HttpGet]
        public ActionResult Delete(int id, int userId)
        {
            using (FittAppContext fitt = new FittAppContext())
            { 
                
                var mode1 = fitt.UserNoGoZones.SingleOrDefault(x => x.NoGoZoneId == id && x.UserId == userId);
                return View(mode1);
            }
            
        }
        [HttpPost]
        public ActionResult Delete1(int userId,int noGoId)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
             
                var userModel = fitt.UserNoGoZones.SingleOrDefault(x => x.NoGoZoneId ==noGoId&& x.UserId == userId); 
                fitt.UserNoGoZones.Remove(userModel);
                fitt.SaveChanges();

            }
              
                return RedirectToAction("UserInfo", "User");
            }
        }
    }
