using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midproject.Controllers
{
    [Authorize]
    public class VolunteerfromaddController : Controller
    {
        // GET: Volunteerfromadd
        public ActionResult Index()
        {

            var db = new ProjectEntities();
            return View(db.UserFroms.ToList());
        }

        public ActionResult Edit(int id)
        {
            var db = new ProjectEntities();
           // var db = new Me2Entities();

            var student = (from s in db.UserFroms
                           where s.Serial == id
                           select s).FirstOrDefault();
            return View(student);

        }
        [HttpPost]
        public ActionResult Edit(UserFrom st)
        {
            var db = new ProjectEntities();
            var student = (from s in db.UserFroms
                           where s.Serial == st.Serial
                           select s).FirstOrDefault();
            db.Entry(student).CurrentValues.SetValues(st);

            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Show()
        {
            var db = new ProjectEntities();
            return View(db.VolunteerFroms.ToList());
        }
        public ActionResult Addstudent()
        {
            ViewBag.Orphanserial = 1;
            return View();
        }
        [HttpPost]
        public ActionResult Addstudent(VolunteerFrom u)
        {
            var db = new ProjectEntities();
            db.VolunteerFroms.Add(u);
            db.SaveChanges();

            return RedirectToAction("Show", "Volunteerfromadd");
        }

        public ActionResult Volprofile(string search)
        {
            var db = new ProjectEntities();
            return View(db.VolunteerLogins.Where(x=>x.Username.StartsWith(search)).ToList());
        }

        public ActionResult VolEdit(int id)
        {
            var db = new ProjectEntities();

            var data = (from s in db.VolunteerLogins
                        where s.Serial == id
                        select s).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult VolEdit(VolunteerLogin v)
        {
            var db = new ProjectEntities();

            var data = (from s in db.VolunteerLogins
                        where s.Serial == v.Serial
                        select s).FirstOrDefault();

            db.Entry(data).CurrentValues.SetValues(v);
            db.SaveChanges();

            return RedirectToAction("Volprofile");

        }

        public ActionResult VolDelete(int id)
        {
            var db = new ProjectEntities();

            var data = (from s in db.VolunteerLogins
                        where s.Serial == id
                        select s).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult VolDelete(VolunteerLogin v)
        {
            var db = new ProjectEntities();

            var data = (from s in db.VolunteerLogins
                        where s.Serial == v.Serial
                        select s).FirstOrDefault();

            db.VolunteerLogins.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Volprofile");
        }
    }
}