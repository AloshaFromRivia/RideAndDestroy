using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace RideAndDestroy.Models
{
    public class ShopDbContext : DbContext, IRepository
    {
        public IEnumerable<Product> Products => _products;


        public ShopDbContext(DbContextOptions<ShopDbContext> options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shop.db");
        }

        public void Add(Product product)
        {
            if (product.Id == 0)
            {
                _products.Add(product);
            }
            else
            {
                Product dbEntry = _products
                    .FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    if (product.Image != null) dbEntry.Image = product.Image;
                }
            }
            SaveChanges();
        }

        public void Remove(int id)
        {
            _products.Remove(_products.First(p=>p.Id==id));
            SaveChanges();
        }

        private DbSet<Product> _products { get; set; }
    }
}
