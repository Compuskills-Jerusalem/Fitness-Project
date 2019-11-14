
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessProject.Web.Mvc.Models;
using System.Web.Security;
using DatabaseConn;
using FitnessProject.Web.Mvc.Services;

namespace FitnessProject.Web.Mvc.Controllers
{

    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name,string email)
        {
            if (ModelState.IsValid)
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
                        fitt.Users.Add(new User { Name = name ,EMail=email});
                        fitt.SaveChanges();
                        FormsAuthentication.SetAuthCookie(name, createPersistentCookie: true);

                    }
                }
            }
            return RedirectToAction("GetAddress", "Location");
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
                //UserInfoModel userInfo = new UserInfoModel();
                var model = from noGo in fitt.UserNoGoZones
                            where noGo.User.Name == User.Identity.Name
                            select new UserInfoModel
                            {
                                Id = noGo.UserNoGoZoneID,
                                Address = noGo.NoGoZones.Address,
                                PlaceName = noGo.NoGoZones.PlaceName,

                            };

                return View(model.AsEnumerable().ToList());
            }
        }
        [HttpGet]
        public ActionResult AccountDetailsLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountDetailsLogin(string name)
        {
            using (var fitt = new FittAppContext())
            {            
                var user = fitt.Users.FirstOrDefault(x => x.Name == name);
                if (user!=null&&name==User.Identity.Name)
                {
                  // FormsAuthentication.SetAuthCookie(name, createPersistentCookie: false);
                    return RedirectToAction("AccountDetails");
                }
                else
                {
                    ModelState.AddModelError("name", "Unknown or unathorized username");
                    return View();
                }
            }
        }
        [HttpGet]
        public ActionResult AccountDetails()
        {
                using (FittAppContext fitt = new FittAppContext())
                {
                
                var model = from customer in fitt.Users
                            where customer.Name == User.Identity.Name
                            select new Users
                            {
                            id=customer.UserID,
                            Name=customer.Name,
                            Email=customer.EMail
                            };
                    return View(model.AsEnumerable().ToList());
                }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.Users.FirstOrDefault(x => x.UserID == id);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Edit(string name, int id, User user)
        {
            name = User.Identity.Name;
                using (FittAppContext fitt = new FittAppContext())
                {
                    var model = fitt.Users.FirstOrDefault(x => x.UserID == id);
                    model.EMail = user.EMail;
                    model.Name = user.Name;
                    fitt.SaveChanges();
                }
            
                return RedirectToAction("Login");        
           }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.Users.FirstOrDefault(x => x.UserID == id);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id,string name)
        {
            name = User.Identity.Name;
            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.Users.Find(id);
                
                
             
            //    var noGo = fitt.NoGoZones.Find(noGoModel);
              //  var no = noGo.NoGoZoneID;
                //  var a= fitt.UserNoGoZones.Any(x => x.UserId == id);
                // var genNoGo = fitt.UserNoGoZones.Find(clientNogos);
                //var genNoGos = genNoGo.NoGoZoneID;
                // var dangerZones = fitt.UserNoGoZones.Where(x => x.NoGoZoneID == genNoGos).Count();
                // var dangerZone = fitt.NoGoZones.FirstOrDefault(x => x.NoGoZoneID == genNoGos);
                // if (dangerZones>1)
                //{
                fitt.Users.Remove(model);
                    fitt.SaveChanges();
               // }
              /*  else
                {
                    fitt.Users.Remove(model);
                    fitt.UserNoGoZones.Remove(genNoGo);
                    fitt.NoGoZones.Remove(dangerZone);
                    fitt.SaveChanges();
                }*/
            }
            return RedirectToAction("index","Home");
        }
        }
    }
