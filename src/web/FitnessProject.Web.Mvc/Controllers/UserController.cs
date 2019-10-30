using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProject.Web.Mvc.Models;
using System.Web.Security;
using DatabaseConn;

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

 
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                if (fitt.Users.Any(x => x.Name == name))
                {
                    ModelState.AddModelError("name", "That name is taken");
                    return View();
                }
                else
                {
                    fitt.Users.Add(new User { Name = name });
                    fitt.SaveChanges();
                    FormsAuthentication.SetAuthCookie(name, createPersistentCookie: true);
                    return RedirectToAction("GetAddress", "Location");
                }
            }
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
                                Id=noGo.NoGoZoneId,
                                Address=noGo.NoGoZone.Address
                            };

             
                            
                return View(model.AsEnumerable().ToList());               
            }

             
        }
        /* GET: User/Edit/5
       public ActionResult Edit(string name)
        {
                var model = User.Identity.Name;
                return View(model);       
        }*/

 

   
    }
}
