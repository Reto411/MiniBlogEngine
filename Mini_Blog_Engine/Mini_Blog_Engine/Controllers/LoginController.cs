using Mini_Blog_Engine.Helpers;
using Mini_Blog_Engine.ViewModels;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class LoginController : ControllerWithDB
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login", new LoginViewModel());
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
            

            loginViewModel.Password = "";
            return View("Login", loginViewModel);
        }
    }
}