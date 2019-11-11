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
  
        [HttpGet]
        public ActionResult GetAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAddress (string address, string name,string place)
        {  
            FindLocationWithGoogleApiModel googleApiModel = new FindLocationWithGoogleApiModel();
           using(FittAppContext fitt=new FittAppContext())
            {
                if(fitt.NoGoZones.Any(x=>x.Address==address))
                {
                    googleApiModel.AddToJoinTable( User.Identity.Name,name);
                
                }
                else
                {
                    googleApiModel.FindLocation(address, User.Identity.Name);
                    googleApiModel.AddToJoinTable( User.Identity.Name,name);
                    fitt.NoGoZones.Add(new NoGoZone { PlaceName = place });
                    fitt.SaveChanges();
                }
            } 
            return RedirectToAction("UserInfo", "User");
        }


  
        }
    }
