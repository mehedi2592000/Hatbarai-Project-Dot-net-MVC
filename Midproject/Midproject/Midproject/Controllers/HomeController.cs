using Midproject.Models.En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Midproject.Controllers
{
    public class HomeController : Controller
    {
        ProjectEntities db = new ProjectEntities();
        public ActionResult Index()
        {
            int q = db.VolunteerLogins.Max(x => x.Serial);
            Session["NumberVolun1"] = q;
            int p = db.AgencyLogins.Max(x => x.Serial);
            Session["NumberAgent2"] = p;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}