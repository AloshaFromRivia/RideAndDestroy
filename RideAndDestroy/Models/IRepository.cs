using System.Collections.Generic;

namespace RideAndDestroy.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void Add(Product product); 
        void Remove(int id);
    }
}
