using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class HomeController : ControllerWithDB
    {
        public ActionResult Index()
        {
            db.Seed();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }


        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}