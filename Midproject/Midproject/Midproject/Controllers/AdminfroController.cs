using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Midproject.Controllers
{
    [Authorize]
    public class AdminfroController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        // GET: Adminfro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminInfo(string search)
        {
            //return View(db.AdminLogins.ToList());
            return View(db.AdminLogins.Where(x => x.Fname.StartsWith(search) || search == null).ToList());

        }
        public ActionResult Edit(int id)
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == id
                         select s).FirstOrDefault();


            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(AdminLogin a)
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == a.Serial
                         select s).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(a);
            db.SaveChanges();

            return RedirectToAction("AdminInfo");
        }
        public ActionResult Delete(int id)
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == id
                         select s).FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Delete(AdminLogin a)
        {
            
            var ad = (from s in db.AdminLogins
                         where s.Serial == a.Serial
                         select s).FirstOrDefault();
            
            db.AdminLogins.Remove(ad);
            db.SaveChanges();

            //return RedirectToAction("AdminInfo");
            return RedirectToAction("AdminInfo");
        }
        //......................................................
            public ActionResult Adminprofile(string search)
            {
            return View(db.AdminLogins.Where(x => x.Username.StartsWith(search)).ToList());
            }
                
            public ActionResult AdminEdit(int id)
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == id
                         select s).FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminEdit(AdminLogin a )
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == a.Serial
                         select s).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(a);
            db.SaveChanges();

            return RedirectToAction("Adminprofile");
        }

        public ActionResult AdminDelete(int id)
        {
            var admin = (from s in db.AdminLogins
                         where s.Serial == id
                         select s).FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminDelete(AdminLogin a)
        {
            var ad = (from s in db.AdminLogins
                      where s.Serial == a.Serial
                      select s).FirstOrDefault();

            db.AdminLogins.Remove(ad);
            db.SaveChanges();

            //return RedirectToAction("AdminInfo");
            return RedirectToAction("Adminprofile");
        }
        //...............

        public ActionResult ListofVolunteer(string search)
        {
            //return View(db.VolunteerLogins.ToList());
            return View(db.VolunteerLogins.Where(x => x.Name.StartsWith(search) || search == null).ToList());
        }
        
        public ActionResult volEdit(int id)
        {
            var admin = (from s in db.VolunteerLogins
                         where s.Serial == id
                         select s).FirstOrDefault();


            return View(admin);
        }
        [HttpPost]
        public ActionResult volEdit(VolunteerLogin a)
        {
            var admin = (from s in db.VolunteerLogins
                         where s.Serial == a.Serial
                         select s).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(a);
            db.SaveChanges();

            return RedirectToAction("ListofVolunteer");
        }
        public ActionResult volDelete(int id)
        {
            var admin = (from s in db.VolunteerLogins
                         where s.Serial == id
                         select s).FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public ActionResult volDelete(VolunteerLogin a)
        {

            var ad = (from s in db.VolunteerLogins
                      where s.Serial == a.Serial
                      select s).FirstOrDefault();

            db.VolunteerLogins.Remove(ad);
            db.SaveChanges();

            //return RedirectToAction("AdminInfo");
            return RedirectToAction("ListofVolunteer");
        }


        public ActionResult voDetails( int id)
        {
            var ad = (from s in db.VolunteerLogins
                      where s.Serial == id
                      select s).FirstOrDefault(); 

            return View(ad);
        }
        //................................
        public ActionResult ListAgency(string search)
        {
            return View(db.AgencyLogins.Where(x => x.Agency_name.StartsWith(search) || search == null).ToList());
        }
        
        public ActionResult AgEdit( int id)
        {
            var admin = (from s in db.AgencyLogins
                         where s.Serial == id
                         select s).FirstOrDefault();


            return View(admin);
        }
        [HttpPost]
        public ActionResult AgEdit(AgencyLogin a)
        {
            var admin = (from s in db.AgencyLogins
                         where s.Serial == a.Serial
                         select s).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(a);
            db.SaveChanges();

            return RedirectToAction("ListAgency");
        }

        public ActionResult AgDelete(int id)
        {
            var admin = (from s in db.AgencyLogins
                         where s.Serial == id
                         select s).FirstOrDefault();
            return View(admin);
        }
            [HttpPost]

        public ActionResult AgDelete(AgencyLogin a)
        {
            var ad = (from s in db.AgencyLogins
                      where s.Serial == a.Serial
                      select s).FirstOrDefault();

            db.AgencyLogins.Remove(ad);
            db.SaveChanges();

            //return RedirectToAction("AdminInfo");
            return RedirectToAction("VolunteerLogins");
        }
            
        public ActionResult AgDetails(int id)
        {
            var ad = (from s in db.AgencyLogins
                      where s.Serial == id
                      select s).FirstOrDefault();

            return View(ad);
        }
        //........................................................
        public ActionResult userlist(string search)
        {
            var ds = db.UserFroms.ToList();

            return View(db.UserFroms.Where(x=>x.Name.StartsWith(search)|| search==null).ToList());
        }
        //..................................................

        public ActionResult Agencylist(string search)
        {
            return View(db.AgencyLogins.Where(x => x.Name.StartsWith(search) || search == null).ToList());
        }
        //.............................
        public ActionResult Vollist(string search)
        {
            return View(db.VolunteerFroms.Where(x => x.Name.StartsWith(search) || search == null).ToList());
        }

        public ActionResult numVolunteer(VolunteerLogin v)
        {
            int q = db.VolunteerLogins.Max(x => x.Serial);
            Session["NumberVolun"] = q;
            return View();
        }

        public ActionResult numAgent(AgencyLogin a)
        {
            int q = db.AgencyLogins.Max(x => x.Serial);
            Session["NumberAgent"] = q;
            return View();
        }
        public ActionResult TotalUsermoney(Usermoney u)
        {
            int a = db.Usermoneys.Sum(x => x.Money);
            Session["totalmoney"] = a;
            return View(db.Usermoneys.ToList());
        }
        public ActionResult totalAgencyget()
        {
            int a = db.Agencymoneys.Sum(x => x.Money);

            var result = db.Agencymoneys.GroupBy(Account => Account.Money).Select(Group => new { Group.Key, Total = Group.Sum(x => x.Money) }).ToList();

            
            Session["totalagen"] = a;
            
            return View(db.Agencymoneys.ToList());
        }

        public ActionResult NetMoney()
        {
            int a = db.Usermoneys.Sum(x => x.Money);
            int b = db.Agencymoneys.Sum(x => x.Money);
            int c = a + b;
            Session["netmoney"] = c;
            return View();
        }
    }
}