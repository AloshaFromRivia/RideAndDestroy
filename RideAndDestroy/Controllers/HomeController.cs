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

        public ViewResult Shop(string productName, string productCategory)
        {
            var products = Repository.Products;
            if (!string.IsNullOrEmpty(productName))
            {
                products = products.Where(x => x.Name.Contains(productName));
            }
            if (!string.IsNullOrEmpty(productCategory))
            {
                products= products.Where(p=>p.Category == productCategory);
            }
            ViewBag.Category= productCategory;
            ViewBag.Title = "Товары";
            return View(products);
        }
    }
}
