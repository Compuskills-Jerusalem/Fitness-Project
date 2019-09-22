using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProjectServerSide.Models;

namespace FitnessProjectServerSide.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                return View(fitt.Users);
            }
                
        }

        /* GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        */
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(string name)
        {
            try
            {
                using (FittAppContext fitt = new FittAppContext())
                {

                    fitt.Users.Add(new User { Name = name });
                    fitt.SaveChanges();
                }
                return RedirectToAction("GetAddress", "Location");
            }
            catch
            {             
            }
            return View();
        }

        // GET: User/Edit/5
     /*   public ActionResult Edit(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.users.id == id)
               return View(model);
            }
            
        }

        // POST: User/Edit/5
       [HttpPost]
        public ActionResult Edit(int id, NoGoZone noGo)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
