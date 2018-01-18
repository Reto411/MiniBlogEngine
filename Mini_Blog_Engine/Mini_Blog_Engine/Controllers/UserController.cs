using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class UserController : ControlerWithDB
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}