using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD:src/web/FitnessProject.Web.Mvc/Controllers/UserController.cs
using FitnessProject.Web.Mvc.Models;
=======
using System.Web.Security;
using FitnessProjectServerSide.Models;
>>>>>>> 2e9c7478e1d333c59a97a4c32061ac089423521f:src/web/FitnessProject.Server/FitnessProjectServerSide/Controllers/UserController.cs

namespace FitnessProject.Web.Mvc.Controllers
{
    
    public class UserController : Controller
    {
        List<User> users = null;
      
        // GET: User
        public ActionResult Index()
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                users = fitt.Users.ToList();
            }
            return View(users);
                
        }

        /* GET: User/Details/5
        public ActionResult Details(int id)
        {

            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.UserNoGoZones.FirstOrDefault(x => x.users.id == id);
                return View(model);
            }
                
        }*/
        
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name)
        {
            using (var fitt = new FittAppContext())
            {
                var user = fitt.Users.FirstOrDefault(x => x.Name == name);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(name, createPersistentCookie: false);
                    return RedirectToAction("UserInfo");
                }
                else
                {
                    ModelState.AddModelError("name", "Unknown username");
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult UserInfo()
        {
            
            using (var fitt = new FittAppContext())
            {
                UserInfoModel userInfo = new UserInfoModel();
                //  e model item passed into the dictionary is of type 'System.Data.Entity.Infrastructure.DbQuery`1[<>f__AnonymousType3`3[System.String,System.Double,System.Double]]', but this dictionary requires a model item of type 'System.Collections.Generic.IEnumerable`1[FitnessProjectServerSide.Models.NoGoZone]'.
                var model = from noGo in fitt.UserNoGoZones
                            where noGo.User.Name == User.Identity.Name
                            select new UserInfoModel
                            {
                                Address = noGo.NoGoZone.Address
                            };

             
                            
                return View(model.AsEnumerable().ToList());
              
                
            }

             
        }
        // GET: User/Edit/5
       public ActionResult Edit(string name)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.Users.Where(x => x.Name == name);
                return View(model);
            }
           
        }

        // POST: User/Edit/5
       [HttpPost]
        public ActionResult Change(User user)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
               
                try
                {
                  //  model.users.Name = user.Name;
                    return RedirectToAction("Index");
                }
                catch
                {                  
                }
                return View();
            }
             
        }

        /* GET: User/Delete/5
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
