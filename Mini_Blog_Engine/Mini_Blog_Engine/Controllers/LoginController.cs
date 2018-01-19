using Mini_Blog_Engine.Helpers;
using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.ViewModels;
using System;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class LoginController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login", new LoginViewModel());
        }

        private ActionResult View(string v, LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public ActionResult Login()
        {
            return View("Login", new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {

            }
            loginViewModel.Password = "";
            return View("Login", loginViewModel);
        }
    }
}