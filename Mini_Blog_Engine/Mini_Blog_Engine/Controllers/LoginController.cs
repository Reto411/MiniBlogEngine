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
            return RedirectToAction("Login");
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
            if (ModelState.IsValid)
            {
                User user = userRepository.GetUserByUsername(HashHelper.Hash(loginViewModel.Username));
                if (user != null)
                {
                    if (HashHelper.CompareStringWithHash(loginViewModel.Password, user.Password))
                    {
                        Token token = tokenRepoitory.CreateToken(user);
                        NexmoServiceHelper.SendTokenSMS(token.TokenNr, user.Mobilephonenumber);
                        ViewBag.LoginStatus = "The One Time Login Token has been sent to your mobile phone.";
                        TokenViewModel tokenViewModel = new TokenViewModel() { UserId = user.Id };
                        return View("LoginToken", tokenViewModel);
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
            } 
            else
            {
                ViewBag.ErrorMessage = "Please fill all fields";
            }
            
            loginViewModel.Password = "";
            return View("Login", loginViewModel);
        }

        [HttpPost]
        public ActionResult LoginToken(TokenViewModel viewModel)
        {
            return View("LoginToken");
        }
    }
}