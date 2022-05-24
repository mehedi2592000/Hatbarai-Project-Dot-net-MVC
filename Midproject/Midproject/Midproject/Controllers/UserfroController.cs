using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midproject.Controllers
{
    [Authorize]
    public class UserfroController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: Userfro
        public ActionResult Index()
        {
            if (Session["Username2"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Addstudent()
        {
            if (Session["Username2"] != null)
            {
                ViewBag.Volenserial = 1;
                string date = DateTime.Now.Date.ToString("dd/MM/yyyy");
                ViewBag.Date = date;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public ActionResult Addstudent(UserFrom u)
        {
            if (Session["Username2"] != null)
            {
                db.UserFroms.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index", "Userfro");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Addmoney()
        {
            if (Session["Username2"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]

        public ActionResult Addmoney(Usermoney u)
        {
            if (Session["Username2"] != null)
            {
                db.Usermoneys.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Userfro");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            


        }

        public ActionResult OrphanList(string name)
        {
            if (Session["Username2"] != null)
            {
                return View(db.UserFroms.Where(x => x.Orphan_name.StartsWith(name) || name == null).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult DonationList()
        {
            if (Session["Username2"] != null)
            {
                return View(db.Usermoneys.Take(10).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult UserProfile()
        {
            if (Session["Username2"] != null)
            {
                string name = Session["Username2"].ToString();
                return View(db.UserLogins.Where(x => x.Username == name).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Edit( int id)
        {
            if (Session["Username2"] != null)
            {
                var data = (from s in db.UserLogins
                            where s.Serial == id
                            select s).FirstOrDefault();

                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]

        public ActionResult Edit(UserLogin u)
        {
            if (Session["Username2"] != null)
            {
                var data = (from s in db.UserLogins
                            where s.Serial == u.Serial
                            select s).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(u);
                db.SaveChanges();
                return RedirectToAction("UserProfile");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

        }

        public ActionResult Delete(int id)
        {
            if (Session["Username2"] != null)
            {
                var data = (from s in db.UserLogins
                            where s.Serial == id
                            select s).FirstOrDefault();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]

        public ActionResult Delete(UserLogin u)
        {
            if (Session["Username2"] != null)
            {
                var data = (from s in db.UserLogins
                            where s.Serial == u.Serial
                            select s).FirstOrDefault();
                db.UserLogins.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Logout", "UserLog");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}