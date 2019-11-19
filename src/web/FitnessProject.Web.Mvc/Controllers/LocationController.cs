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
            return View(models.AsEnumerable());

        }
        public ActionResult Create()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult GetLadLon(string address)
        {
            GeoCoordinate LadLonAddress = GetLatitudeLongitudeFromAddress.FindLocation(address);
            LocationMap Location = new LocationMap { Latitude = LadLonAddress.Latitude, Longitude = LadLonAddress.Longitude, Description="Hallo", Title="Blabla"};
            return Json(Location, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string address, string placeName)
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
        public ActionResult Details(int? id)
        {
            var TempNoGo = db.NoGoZones.Find(id);
            if (TempNoGo.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(new UserInfoModel
            {
                PlaceName = TempNoGo.PlaceName,
                Address = TempNoGo.Address,
                Id = TempNoGo.NoGoZoneID
            });
        }
        public ActionResult Edit(int id)
        {
            var TempNoGo = db.NoGoZones.Find(id);
            if (TempNoGo.UserId!=User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(new UserInfoModel
            {
                PlaceName=TempNoGo.PlaceName,
                Address=TempNoGo.Address,
                Id=TempNoGo.NoGoZoneID
            });
        }

        [HttpPost]
        public ActionResult Edit(string address, string placeName, int id)
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
                var EditNoGo = db.NoGoZones.Find(id);
                if (EditNoGo.UserId != User.Identity.GetUserId())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }
                EditNoGo.Latitude = LadLonAddress.Latitude;
                EditNoGo.Longitude = LadLonAddress.Longitude;
                EditNoGo.PlaceName = placeName;
                EditNoGo.Address = address;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var TempNoGo = db.NoGoZones.Find(id);
            if (TempNoGo.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            return View(new UserInfoModel
            {
                PlaceName = TempNoGo.PlaceName,
                Address = TempNoGo.Address,
                Id = TempNoGo.NoGoZoneID
            });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var TempNoGo = db.NoGoZones.Find(id);
            if (TempNoGo.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            db.NoGoZones.Remove(TempNoGo);
            db.SaveChanges();
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