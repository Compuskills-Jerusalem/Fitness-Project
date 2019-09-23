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
      //  List<NoGoZone> noGos = null;
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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult UserInfo(string name)
        {

            using (var fitt = new FittAppContext())
            {

                //  e model item passed into the dictionary is of type 'System.Data.Entity.Infrastructure.DbQuery`1[<>f__AnonymousType3`3[System.String,System.Double,System.Double]]', but this dictionary requires a model item of type 'System.Collections.Generic.IEnumerable`1[FitnessProjectServerSide.Models.NoGoZone]'.
                var model = from person in fitt.UserNoGoZones
                            where person.users.Name == name

                            select person.UserNoGoZones.Address;
              
                    //noGos = fitt.NoGoZones.ToList();
                // person.UserNoGoZones.Laditude,
                // person.UserNoGoZones.Longitude

                //  string a = Convert.ToString(model);
                return View(model);
            }
               
            
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
