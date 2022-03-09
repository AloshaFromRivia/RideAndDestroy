using Microsoft.AspNetCore.Mvc;
using RideAndDestroy.Models;
using System.Linq;
using System.Collections.Generic;

namespace RideAndDestroy.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repository { get; set; }
        public HomeController(IRepository repo)
        {
            Repository = repo;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Главная";
            return View();
        }

        public ViewResult Shop(string id)
        {
            var products = Repository.Products;
            if (!string.IsNullOrEmpty(id))
            {
                products = products.Where(x => x.Name.Contains(id));
            }
            ViewBag.Title = "Каталог";
            return View(products);
        }

       
    }
}
