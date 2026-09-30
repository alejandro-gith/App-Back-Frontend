using System.Collections.Generic;
using System.Linq;
using MiApp.Domain.Dtos;
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

        public List<ProductResponseDto> GetAll()
        {
            var products = _productRepository.GetAll();

            // Convierte las entidades en DTOs para la respuesta.
            return products.Select(product => new ProductResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Category = product.Category,
                Description = product.Description,
                Image = product.Image
            }).ToList();
        }
    }
}