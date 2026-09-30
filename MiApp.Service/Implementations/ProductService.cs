using System;
using System.Collections.Generic;
using System.Linq;
using MiApp.Domain.Dtos;
using MiApp.Domain.Entities;
using MiApp.Repository.Interfaces;
using MiApp.Service.Interfaces;

namespace MiApp.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductResponseDto> GetAll()
        {
            return _productRepository.GetAll().Select(MapToDto).ToList();
        }

        public IEnumerable<string> GetCategories()
        {
            return _productRepository.GetCategories().ToList();
        }

        public IEnumerable<ProductResponseDto>? GetByCategory(string category)
        {
            // Regla de negocio: la categoría no puede estar vacía
            if (string.IsNullOrWhiteSpace(category))
            {
                return null;
            }

            // Regla de negocio: la categoría debe existir
            var categoryExists = _productRepository.GetCategories()
                .Any(c => c.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (!categoryExists)
            {
                return null;
            }

            return _productRepository.GetByCategory(category).Select(MapToDto).ToList();
        }

        private static ProductResponseDto MapToDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Category = product.Category,
                Description = product.Description,
                Image = product.Image
            };
        }
    }
}
