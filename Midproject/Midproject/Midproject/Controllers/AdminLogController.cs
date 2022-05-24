using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Midproject.Controllers
{
    public class AdminLogController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: AdminLog
        public ActionResult Index()

        { 
            return View(db.AdminLogins.ToList());
        }

        
        public ActionResult SignUp()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AdminLogin a)
        {
            if(db.AdminLogins.Any(x=>x.Username==a.Username))
            {
                ViewBag.Notification = "There will be same username";
                return View();
            }
            else
            {
                db.AdminLogins.Add(a);
                db.SaveChanges();
                Session["Type"] = a.Type.ToString();

                Session["Username"] = a.Username.ToString();

                return RedirectToAction("Login", "AdminLog");

            }
            
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLogin a)
        {
            var data = db.AdminLogins.Where(x => x.Username == a.Username && x.Password == a.Password).FirstOrDefault();
            
            if(data!=null)
            {
                //Session["Type"] = 1;
                Session["Username"] = a.Username.ToString();
               FormsAuthentication.SetAuthCookie(a.Username,true);
                return RedirectToAction("Index", "Adminfro");
            }
            else
            {
                ViewBag.log = "your validatation is not correct";
            }

            return View();
        }
       /*
        public ActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forget(AdminLogin a)
        {
            if (db.AdminLogins.Any(x => x.Username == a.Username))
            {
                db.AdminLogins.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index", "AdminLog");
            }
            else
            {
                return View();
            }
        }

        */
            public ActionResult Logout()
            {
                 Session.Clear();
                 return RedirectToAction("Index", "Home");
            }
    }
}