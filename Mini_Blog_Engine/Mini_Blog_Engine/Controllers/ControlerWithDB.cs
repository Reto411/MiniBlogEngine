using M183_Blog.Models;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class ControlerWithDB : Controller
    {
        protected DataContext db = new DataContext();


    }
}