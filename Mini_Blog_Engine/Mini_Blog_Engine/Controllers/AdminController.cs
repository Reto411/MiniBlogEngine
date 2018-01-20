using Mini_Blog_Engine.Helpers;
using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.Repository;
using Mini_Blog_Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class AdminController : Controller
    {
        public DataContext db = new DataContext();

        private UserRepository userRepository;
        private PostRepository postRepository;

        public AdminController()
        {
            userRepository = new UserRepository(db);
            postRepository = new PostRepository(db);
        }

        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult Dashboard()
        {
            // first check if session is valid
            if(userRepository.IsSessionValid((int)Session[ConstHelper.SessionDefaultName], Session.SessionID, Request.UserHostAddress))
            {
                var posts = postRepository.GetAllPost();
                PublishedPostListViewModel listPostViewModel = new PublishedPostListViewModel(posts);
                return View("Dashboard", listPostViewModel);
            }

            ViewBag.ErrorMessage = "Your Session is invalid, please log in again";
            return RedirectToAction("Logout", "Login");
        }
    }
}