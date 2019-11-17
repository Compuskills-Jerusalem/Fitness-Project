using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProject.Web.Domain;
using FitnessProject.Web.Mvc.Models;
using FitnessProject.Web.Notifications;

namespace FitnessProject.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
