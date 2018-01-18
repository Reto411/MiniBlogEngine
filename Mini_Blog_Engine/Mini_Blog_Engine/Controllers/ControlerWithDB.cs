using Mini_Blog_Engine.Models;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class ControllerWithDB : Controller
    {
        protected DataContext db = new DataContext();

    }
}