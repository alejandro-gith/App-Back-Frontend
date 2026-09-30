using System.Collections.Generic;
using System.Linq;
using MiApp.Domain.Entities;
using MiApp.Repository.Data;
using MiApp.Repository.Interfaces;

namespace MiApp.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAll()
        {
            // Devuelve una copia de la lista de productos.
            return InMemoryData.Products.ToList();
        }
    }
}
