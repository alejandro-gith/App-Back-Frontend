using System.Collections.Generic;
using MiApp.Domain.Entities;

namespace MiApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<string> GetCategories();
        IEnumerable<Product> GetByCategory(string category);
    }
}
