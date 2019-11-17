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
using FitnessProject.Web.GetLatitudeLongitudeFromAddress;
using System.Device.Location;
using Microsoft.AspNet.Identity;

namespace FitnessProjectServerSide.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private FitnessAppContext db = new FitnessAppContext();
        public ActionResult Index()
        {
            var TempUser = User.Identity.GetUserId();
            var models = db.NoGoZones.Where(x => x.UserId == TempUser).Select(x => new UserInfoModel
            {
                Address = x.Address,
                PlaceName = x.PlaceName,
                Id= x.NoGoZoneID
            });
            return View(models.AsEnumerable().ToList());

        }
        public ActionResult GetAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAddress(string address, string placeName)
        {

            if (address == string.Empty)
            {
                ModelState.AddModelError("address", "Please add a Address");
                return View();
            }
            if (placeName == string.Empty)
            {
                ModelState.AddModelError("placeName", "Please add a Name");
                return View();
            }
            else
            {
                GeoCoordinate LadLonAddress = GetLatitudeLongitudeFromAddress.FindLocation(address);
                db.NoGoZones.Add(new NoGoZone
                {
                    PlaceName=placeName,
                    UserId= User.Identity.GetUserId(),
                    Latitude=LadLonAddress.Latitude,
                    Longitude=LadLonAddress.Longitude,
                    Address=address,
                });
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}