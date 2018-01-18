using M183_Blog.Models;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class ControllerWithDB : Controller
    {
        protected DataContext db = new DataContext();

    }
}