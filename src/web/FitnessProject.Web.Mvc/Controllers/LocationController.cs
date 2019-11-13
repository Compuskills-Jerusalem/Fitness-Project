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
using FitnessProject.Web.Mvc.Services;

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
        public ActionResult GetAddress ( string name,string address,string place)
        {  
            FindLocationWithGoogleApiModel googleApiModel = new FindLocationWithGoogleApiModel();
            AddRemoveFromDbModel addRemoveFromDb = new AddRemoveFromDbModel();
          
                using (FittAppContext fitt = new FittAppContext())
                {
                    if (fitt.NoGoZones.Any(x => x.Address == address))
                    {
                        addRemoveFromDb.AddToJoinTable(User.Identity.Name, address);                   
                    }
                    else
                    {
                        googleApiModel.FindLocation(address,User.Identity.Name,place);
                        addRemoveFromDb.AddToJoinTable(User.Identity.Name, address);
                       
                    }
                }
            
            return RedirectToAction("UserInfo", "User");
        }


  
        }
    }
