using System;
using System.Collections.Generic;
using System.Linq;
using MiApp.Domain.Entities;
using MiApp.Repository.Data;
using MiApp.Repository.Interfaces;

namespace MiApp.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            // Devuelve una copia para no exponer la lista compartida
            return InMemoryData.Products.ToList();
        }

        public IEnumerable<string> GetCategories()
        {
            // Categorías únicas, sin importar mayúsculas o minúsculas
            return InMemoryData.Products
                .Select(p => p.Category)
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            return InMemoryData.Products
                .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
    }
}

