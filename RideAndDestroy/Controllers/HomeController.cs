using Microsoft.AspNetCore.Mvc;

namespace RideAndDestroy.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Главная";
            return View();
        }
    }
}
