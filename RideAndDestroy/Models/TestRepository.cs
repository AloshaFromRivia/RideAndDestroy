using System.Collections.Generic;

namespace RideAndDestroy.Models
{
    public class TestRepository : IRepository
    {
        private List<Product> _products;
        private List<Category> _categories;
        public IEnumerable<Product> Products => _products;

        public IEnumerable<Category> Categories => _categories;

        public TestRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Name ="Велосипед 1",
                    CategoryId = 1,
                    Description="Крутой товар",
                    Price = 10000
                },
                  new Product()
                {
                    Name ="Велосипед 2",
                    CategoryId = 1,
                    Description="Тоже Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Каска",
                    CategoryId = 2,
                    Description="Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Каска1",
                    CategoryId = 2,
                    Description="Крутой товар",
                    Price = 10000
                },
                 new Product()
                {
                    Name ="Куртка",
                    CategoryId = 3,
                    Description="Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Пружина",
                    CategoryId = 4,
                    Description="Крутой товар",
                    Price = 10000
                }
            };
            _categories = new List<Category>() 
            {
                new Category()
                {
                    Id= 1,
                    Name="Велосипед"
                },
                 new Category()
                {
                    Id= 2,
                    Name="Защиты"
                },
                new Category()
                {
                    Id= 3,
                    Name="Одежда"
                },
                new Category()
                {
                    Id= 4,
                    Name="Запчасти"
                },
            };
        }
    }
}
