using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Midproject.Controllers
{
    public class UserLogController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: UserLog
        public ActionResult Index()
        {
            return View(db.UserLogins.ToList());
        }

        public ActionResult Signup()
        {
            string Datestring = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ViewBag.Date = Datestring;
            ViewBag.Type = 2;
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserLogin u)
        {
            if (db.UserLogins.Any(x => x.Username == u.Username))
            {
                
                ViewBag.log = "Username is already taken!";
                return View();
            }
            else
            {
                db.UserLogins.Add(u);
                db.SaveChanges();

                Session["Complet"] = u.Username.ToString();

                return RedirectToAction("Login", "UserLog");

            }
        }

        public JsonResult CheckUserName(string userdata)
        {
            if (!String.IsNullOrEmpty(userdata) && !String.IsNullOrWhiteSpace(userdata))
            {
                System.Threading.Thread.Sleep(200);
                var SearchData = db.UserLogins.Where(x => x.Username == userdata).SingleOrDefault();
                if (SearchData != null)
                {
                    return Json(1);
                }
                else
                {
                    return Json(0);
                }
            }
            else
            {
                return Json(-1);
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin u)
        {
            var data = db.UserLogins.Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();

            if (data != null)
            {
                Session["Type"] = 2;
                Session["Username2"] = u.Username.ToString();
                FormsAuthentication.SetAuthCookie(u.Username, true);
                //FormsAuthentication.SetAuthCookie(a.Fname, true);
                return RedirectToAction("Index", "Userfro");
            }
            else
            {
                ViewBag.log = "Username or password is incorrect!";
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}