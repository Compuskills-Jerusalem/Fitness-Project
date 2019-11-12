
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
                UserInfoModel userInfo = new UserInfoModel();
                //  e model item passed into the dictionary is of type 'System.Data.Entity.Infrastructure.DbQuery`1[<>f__AnonymousType3`3[System.String,System.Double,System.Double]]', but this dictionary requires a model item of type 'System.Collections.Generic.IEnumerable`1[FitnessProjectServerSide.Models.NoGoZone]'.
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
        public ActionResult AccountDetails()
        {
            using (FittAppContext fitt = new FittAppContext())
            {
                AccountDetails accountDetails = new AccountDetails();
                var model = from client in fitt.Users
                            where client.Name == User.Identity.Name
                            select new AccountDetails
                            {
                                UserId = client.UserID,
                                UserName = client.Name,
                                Email = client.EMail
                            };
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult EditAccountDetails(int id)
        {

            using (FittAppContext fitt = new FittAppContext())
            {
                var model = fitt.Users.FirstOrDefault(x => x.UserID == id);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditAccountDetails(string name, int id, User user)
        {
            name = User.Identity.Name;
            if (ModelState.IsValid)
            {
                using (FittAppContext fitt = new FittAppContext())
                {
                    var model = fitt.Users.FirstOrDefault(x => x.UserID == id);
                    model.EMail = user.EMail;
                    model.Name = user.Name;
                    fitt.SaveChanges();
                }
            }
            return RedirectToAction("UserInfo");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (FittAppContext fitt = new FittAppContext())
            {

                var mode1 = fitt.UserNoGoZones.SingleOrDefault(x => x.UserNoGoZoneID == id);
                return View(mode1);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, string name)
        {
            name = User.Identity.Name;
            using (FittAppContext fitt = new FittAppContext())
            {
                DeleteModel deleteModel = new DeleteModel();
                var model = fitt.UserNoGoZones.Find(id);
                var mod4el = model.NoGoZoneID;
                var mo = fitt.NoGoZones.Find(mod4el);
                var m = fitt.UserNoGoZones.Where(x => x.NoGoZoneID == mod4el).Count();
                if (m > 2)
                {
                    fitt.UserNoGoZones.Remove(model);
                    fitt.SaveChanges();
                }
                else
                {
                    fitt.UserNoGoZones.Remove(model);
                    fitt.NoGoZones.Remove(mo);
                    fitt.SaveChanges();
                }



                return RedirectToAction("UserInfo");
            }
        }
    }
}
