using Mini_Blog_Engine.Helpers;
using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.Repository;
using Mini_Blog_Engine.ViewModels;
using System;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Mini_Blog_Engine.Controllers
{
    public class LoginController : Controller
    {
        public DataContext db = new DataContext();

        private UserRepository userRepository;
        private TokenRepository tokenRepository;

        public LoginController()
        {
            userRepository = new UserRepository(db);
            tokenRepository = new TokenRepository(db);
        }

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
            try
            {
                if (ModelState.IsValid)
                {
                    User user = userRepository.GetUserByUsername(loginViewModel.Username);
                    if (user != null)
                    {
                        if (HashHelper.CompareStringWithHash(loginViewModel.Password, user.Password))
                        {
                            Token token = tokenRepository.CreateToken(user);
                            NexmoServiceHelper.SendTokenSMS(token.TokenNr, user.Mobilephonenumber);
                            ViewBag.LoginStatus = "The One Time Login Token has been sent to your mobile phone.";
                            TokenViewModel tokenViewModel = new TokenViewModel()
                            {
                                UserId = user.Id,
                                Password = loginViewModel.Password,
                                Username = loginViewModel.Username
                            };
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
            }
            catch (Exception ex)
            {
                userRepository.AddUserLog(null, "Login Failed with error" + ex.Message);
                ViewBag.ErrorMessage = "Technical Errors occured";
                return View();
            }

            loginViewModel.Password = "";
            return View("Login", loginViewModel);
        }

        /// <summary>
        /// In der aufgabenstellung wurde explizit verlangt dass  das password und username nochmal geprüft wird.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoginToken(TokenViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = userRepository.GetUserByUsername(viewModel.Username);
                    if (user != null)
                    {
                        if (HashHelper.CompareStringWithHash(viewModel.Password, user.Password))
                        {
                            var token = tokenRepository.GetTokenValid(viewModel.Token, user.Id);
                            if (token != null)
                            {
                                try
                                {
                                    // Mark token as deleted
                                    userRepository.AddUserLog(user.Id, "Logged in successful");
                                    token.DeletedOn = DateTime.Now;
                                    db.SaveChanges();

                                    // Create Session
                                    Session[ConstHelper.SessionDefaultName] = user.Id;
                                    // Add to db
                                    userRepository.CreateUserLogInForUserId(user.Id, Request.UserHostAddress, Session.SessionID);

                                    SessionIDManager sessionIdManager = new SessionIDManager();
                                    string sessionId = sessionIdManager.CreateSessionID(System.Web.HttpContext.Current);

                                    // Redirect authenticated user

                                    if (user.Role == ((int)(UserRole.Admin)).ToString())
                                    {
                                        return RedirectToAction("Dashboard", "Admin");
                                    }
                                    if (user.Role == ((int)(UserRole.User)).ToString())
                                    {
                                        return RedirectToAction("Dashboard", "User");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    userRepository.AddUserLog(user.Id, "Login Failed with error" + ex.Message);
                                    ViewBag.ErrorMessage = "Technical Errors occured";
                                    return View();
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Token invalid, Try again!";
                                return View("LoginToken", viewModel);
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Pssword invalid";
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {
                        viewModel.Username = "";
                        ViewBag.ErrorMessage = "User doesn't exist";
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Please fill all fields";
                    return RedirectToAction("Login");
                }
                return View("LoginToken", viewModel);
            }
            catch (Exception ex)
            {
                userRepository.AddUserLog(null, "Login Failed with error" + ex.Message);
                ViewBag.ErrorMessage = "Technical Errors occured";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}