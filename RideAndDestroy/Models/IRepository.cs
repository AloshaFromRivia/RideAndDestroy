using System.Collections.Generic;

namespace RideAndDestroy.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Category> Categories { get; }
    }
}
