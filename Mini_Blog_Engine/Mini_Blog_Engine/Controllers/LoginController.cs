using Mini_Blog_Engine.Helpers;
using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.Repository;
using Mini_Blog_Engine.ViewModels;
using System;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class LoginController : Controller
    {
        private UserRepository userRepository = new UserRepository();
        private TokenRepository tokenRepoitory = new TokenRepository();
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
            User user = userRepository.GetUserByUsername(HashHelper.Hash(loginViewModel.Username));
            if (user != null)
            {
                if(HashHelper.CompareStringWithHash(loginViewModel.Password, user.Password))
                {
                    Token token = tokenRepoitory.CreateToken(user);
                    
                }
                else
                {
                    ViewBag.ErrorMessage = "Logindata Invalid";
                }
            }
            else
            {
                loginViewModel.Username = "";
                ViewBag.ErrorMessage = "User doesn't exist";
            }
            loginViewModel.Password = "";
            return View("Login", loginViewModel);
        }
    }
}