using System.Collections.Generic;

namespace RideAndDestroy.Models
{
    public class TestRepository : IRepository
    {
        private List<Product> _products;
        public IEnumerable<Product> Products => _products;

        public TestRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Name ="Велосипед 1",
                    Category = "Велосипед",
                    Description="Крутой товар",
                    Price = 10000
                },
                  new Product()
                {
                    Name ="Велосипед 2",
                    Category = "Велосипед",
                    Description="Тоже Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Каска",
                    Category = "Защита",
                    Description="Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Каска1",
                    Category = "Защита",
                    Description="Крутой товар",
                    Price = 10000
                },
                 new Product()
                {
                    Name ="Куртка",
                    Category = "Одежда",
                    Description="Крутой товар",
                    Price = 10000
                },
                new Product()
                {
                    Name ="Пружина",
                    Category = "Запчасти",
                    Description="Крутой товар",
                    Price = 10000
                }
            };
        }
    }
}
