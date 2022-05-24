using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Midproject.Controllers
{
    public class VolunteerLogController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: VolunteerLog
        public ActionResult Index()
        {
            return View(db.VolunteerLogins.ToList());
        }

        public ActionResult Signup()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Signup(VolunteerLogin v)
        {
            if (db.VolunteerLogins.Any(x => x.Username == v.Username))
            {
                ViewBag.Notification = "There will be same username";
                return View();
            }
            else
            {
                db.VolunteerLogins.Add(v);
                db.SaveChanges();

                Session["Complet"] = v.Username.ToString();

                return RedirectToAction("Login", "VolunteerLog");

            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(VolunteerLogin v)
        {
            var da = db.VolunteerLogins.Where(x => x.Username == v.Username && x.Password == v.Password && x.Type==1).FirstOrDefault();
            var data = db.VolunteerLogins.Where(x => x.Username == v.Username && x.Password == v.Password).FirstOrDefault();
            
            
            
                if (data != null)
                {
                    if (da != null)
                    {
                        Session["Type"] = 4;
                        Session["Username4"] = v.Username.ToString();
                    FormsAuthentication.SetAuthCookie(v.Username, true);
                    return RedirectToAction("Index", "Volunteerfromadd");
                    }
                    else
                    {
                        ViewBag.logg = "You are not validate Now , please wait";
                    }
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

        public ActionResult U()
        {
            return View(db.VolunteerLogins.ToList());
        }


    }
}