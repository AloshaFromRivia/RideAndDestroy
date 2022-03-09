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

        public ViewResult Shop(string productName, int productCategoryId=0)
        {
            var products = Repository.Products;
            if (!string.IsNullOrEmpty(productName))
            {
                products = products.Where(x => x.Name.Contains(productName));
            }
            if (productCategoryId!=0)
            {
                products= products.Where(p=>p.CategoryId == productCategoryId);
            }
            ViewBag.Title = "Каталог";
            return View(products);
        }
    }
}
