using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Midproject.Controllers
{
    
    public class AgencyLogController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: AgencyLog
        public ActionResult Index()
        {
            return View(db.AgencyLogins.ToList());
        }
        public ActionResult Signup()
        {
            ViewBag.Type = 3;
            return View();
        }
        [HttpPost]
        public ActionResult Signup(AgencyLogin o)
        {
            if (db.AgencyLogins.Any(x => x.Username == o.Username))
            {
                ViewBag.log = "Username is taken!";
                return View();
            }
            else
            {
                db.AgencyLogins.Add(o);
                db.SaveChanges();

                Session["Complet"] = o.Username.ToString();

                return RedirectToAction("Login", "AgencyLog");

            }
        }

        public JsonResult CheckUserName(string userdata)
        {
            if (!String.IsNullOrEmpty(userdata) && !String.IsNullOrWhiteSpace(userdata))
            {
                System.Threading.Thread.Sleep(200);
                var SearchData = db.AgencyLogins.Where(x => x.Username == userdata).SingleOrDefault();
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

        public ActionResult Login(AgencyLogin o)
        {
            var data = db.AgencyLogins.Where(x => x.Username == o.Username && x.Password == o.Password).FirstOrDefault();

            if (data != null)
            {
                Session["Type"] = 3;
                Session["Username3"] = o.Username.ToString();
                Session["Serial3"] = data.Serial.ToString();
                FormsAuthentication.SetAuthCookie(o.Username, true);
                return RedirectToAction("Do", "Agencyfro");
            }
            else
            {
                ViewBag.log = "your validatation is not correct";
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