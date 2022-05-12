using Microsoft.AspNetCore.Mvc;
using RideAndDestroy.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;

namespace RideAndDestroy.Controllers {
    public class AdminController : Controller {
        private IRepository repository;
        private IWebHostEnvironment _hostEnvironment;

        public AdminController(IRepository repo, IWebHostEnvironment webHost) {
            repository = repo;
            _hostEnvironment = webHost;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.Id == productId));
        
        [HttpPost]
        public IActionResult Edit(Product product,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null) product.Image = GetBytesFromImage(image);
                else product.Image = repository.Products.First(p => p.Id == product.Id).Image;
                repository.Add(product);
                TempData["message"] = $"{product.Name} был сохранен";
                return RedirectToAction("Index");
            } else 
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId) {
           repository?.Remove(productId);
            return RedirectToAction("Index");
        }

        private byte[] GetBytesFromImage(IFormFile file)
        {
            byte[] fileBytes = null;
            if (file.Length > 0)
            {

                using (var fs1 = file.OpenReadStream())
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    fileBytes = ms1.ToArray();
                }
            }

            return fileBytes;
        }
        
    }
}
