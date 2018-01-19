using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.Repository;
using Mini_Blog_Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class HomeController : Controller
    {

        /*
         * Antwort 
         * 
         * 1: Wir haben den Hash-Algorithmus PBKDF2 ausgewählt weil
         *    es eines der empfohlenen und am meisten gebrauchten Hash ist.
         * 
         * 2: Session-Id theft und Eavesdropping
         * 
         * 3: Die Cookies werden mithilfe von Javascript ausgelesen. 
         *    Als Schutz kann die Webseite die Ip des Cookies und die Ip der Maschiene vergleichen,
         *    nur wenn die Ip übereinstimmt hat der User Zugriff.
         * 
         */
        public DataContext db = new DataContext();

        private PostRepository postRepo;

        public HomeController()
        {
            postRepo = new PostRepository(db);
        }


        public ActionResult Index()
        {
            db.Seed();
            List<Post> postList = postRepo.GetPublishedPostList();
            PublishedPostListViewModel listPostViewModel = new PublishedPostListViewModel(postList);
            return View(listPostViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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