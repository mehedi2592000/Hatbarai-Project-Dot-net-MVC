using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midproject.Controllers
{
    [Authorize]
    public class AgencyfroController : Controller
    {
        // GET: Agencyfro
        ProjectEntities db = new ProjectEntities();

        

        public ActionResult Index()
        {
            return RedirectToAction("Do");
        }

        public ActionResult AddChild()
        {
            if (Session["Username3"] != null)
            {
                return View(db.VolunteerFroms.Where(x => x.Orphanserial == 1).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        
        public ActionResult Edit(int id)
        {
            if (Session["Username3"] != null)
            {
                var student = (from s in db.VolunteerFroms
                               where s.Serial == id
                               select s).FirstOrDefault();
                return View(student);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

            //return View();
        }
        [HttpPost]
        public ActionResult Edit(VolunteerFrom st)
        {
            var student = (from s in db.VolunteerFroms
                           where s.Serial == st.Serial
                           select s).FirstOrDefault();

            db.Entry(student).CurrentValues.SetValues(st);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult AcceptChild(int id)
        {
            VolunteerFrom vt = db.VolunteerFroms.Where(x => x.Serial == id).FirstOrDefault();
            int serial = int.Parse(Session["Serial3"].ToString());
            vt.Orphanserial = serial;
            var child = (from s in db.VolunteerFroms
                         where s.Serial == id
                         select s).FirstOrDefault();

            db.Entry(child).CurrentValues.SetValues(vt);
            db.SaveChanges();

            return RedirectToAction("AddChild");
        }

        public ActionResult AgencyProfile() 
        {
            if (Session["Username3"] != null)
            {
                string username = Session["Username3"].ToString();
                return View(db.AgencyLogins.Where(x => x.Username == username).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult OrphansList(string name)
        {
            if (Session["Username3"] != null)
            {
                int id = int.Parse(Session["Serial3"].ToString());
                List<VolunteerFrom> vl = db.VolunteerFroms.Where(x => x.Orphanserial == id).ToList();
                List<UserFrom> uf = new List<UserFrom>();
                foreach (var item in vl)
                {
                    List<UserFrom> tempuf = db.UserFroms.Where(x => x.Serial == item.Userserial).ToList();
                    if (tempuf.Any())
                    {
                        uf.AddRange(tempuf);
                    }
                }
                List<UserFrom> finalList = uf.Distinct().ToList();
                if (name == null)
                {
                    return View(finalList);
                }
                else
                {
                    return View(finalList.Where(x => x.Orphan_name.StartsWith(name)).ToList());
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            
        }

        public ActionResult Payments() 
        {
            if (Session["Username3"] != null)
            {
                string name = Session["Username3"].ToString();
                AgencyLogin instance = db.AgencyLogins.Where(x => x.Username == name).FirstOrDefault();
                return View(db.Agencymoneys.Where(x => x.Agency_name.StartsWith(instance.Agency_name)).ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Do()
        {
            if (Session["Username3"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult AmAdd()
        {
            if (Session["Username3"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]

        public ActionResult AmAdd(Agencymoney a)
        {
            db.Agencymoneys.Add(a);
            db.SaveChanges();

            return RedirectToAction("Do");
        }

        public ActionResult OrphaneEdit(int id)
        {
            if (Session["Username3"] != null)
            {
                var data = (from s in db.UserFroms
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
        public ActionResult OrphaneEdit(UserFrom u)
        {
            var data = (from s in db.UserFroms
                        where s.Serial == u.Serial
                        select s).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(u);
            db.SaveChanges();

            return RedirectToAction("OrphansList");

        }

        public ActionResult AgenEdit(int id)
        {
            if (Session["Username3"] != null)
            {
                var data = (from s in db.AgencyLogins
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
        public ActionResult AgenEdit(AgencyLogin u)
        {
            var data = (from s in db.AgencyLogins
                        where s.Serial == u.Serial
                        select s).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(u);
            db.SaveChanges();

            return RedirectToAction("Agencyprofile");

        }

        public ActionResult AgenDelete(int id)
        {
            if (Session["Username3"] != null)
            {
                var data = (from s in db.AgencyLogins
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

        public ActionResult AgenDelete(AgencyLogin u)
        {
            var data = (from s in db.AgencyLogins
                        where s.Serial == u.Serial
                        select s).FirstOrDefault();
            db.AgencyLogins.Remove(data);
            return RedirectToAction("Agencyprofile");
        }
    }
}