using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json; 
using System.Net;
using FitnessProject.Web.Domain;
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
        public ActionResult GetAddress(string address, string username, string placeName)
        {
            FindLocationWithGoogleApiModel googleApiModel = new FindLocationWithGoogleApiModel();
            AddRemoveFromDbModel addRemoveFromDb = new AddRemoveFromDbModel();
            if (address == string.Empty)
            {
                ModelState.AddModelError("address", "please add a address");
                return View();
            }
            else {
                using (FittAppContext fitt = new FittAppContext())
                {
                    if (fitt.NoGoZones.Any(x => x.Address == address))
                    {
                        addRemoveFromDb.AddToJoinTable(User.Identity.Name, address);
                    }
                    else
                    {
                        googleApiModel.FindLocation(address, User.Identity.Name, placeName);
                        addRemoveFromDb.AddToJoinTable(User.Identity.Name, address);

                    }
                }
                   
                }
            
            return RedirectToAction("UserInfo", "User");
        }
       
        [HttpGet]
        public ActionResult LocationDelete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var models = from location in fitt.UserNoGoZones
                             where location.UserNoGoZoneID == id
                             select new UserInfoModel
                             {
                                 Address = location.NoGoZones.Address,
                                 PlaceName = location.NoGoZones.PlaceName
                             };
           //     var model = fitt.UserNoGoZones.SingleOrDefault(x => x.UserNoGoZoneID == id);
                return View(models.AsEnumerable().ToList());
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult LocationDelete(int id, string name)
        {
            name = User.Identity.Name;
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.Find(id);
                var noGoModel = model.NoGoZoneID;
                var number = fitt.UserNoGoZones.Where(x => x.NoGoZoneID == noGoModel).Count();
                var noGo = fitt.NoGoZones.Find(noGoModel);
                if (number > 1)
                {
                    fitt.UserNoGoZones.Remove(model);
                    fitt.SaveChanges();
                }
                else
                {
                    fitt.UserNoGoZones.Remove(model);
                    fitt.NoGoZones.Remove(noGo);
                    fitt.SaveChanges();
                }
            }
                return RedirectToAction("UserInfo","User");
            }
        }
    }