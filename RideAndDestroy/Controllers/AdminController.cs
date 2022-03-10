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
        public IActionResult Edit(Product product)
            {
             
            if (ModelState.IsValid) {
                ////Save image to wwwroot/image
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(items.file.FileName);
                //string extension = Path.GetExtension(items.file.FileName);
                //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    items.file.CopyToAsync(fileStream);
                //    items.product.Image= System.IO. File.ReadAllBytes(path);
                //}
                ////Insert record
                repository.Add(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
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

    }
}
