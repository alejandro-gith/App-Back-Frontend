using Microsoft.AspNetCore.Mvc;
using MiApp.Service.Interfaces;

namespace MiApp.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Escenario 3: todos los productos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // Escenario 1: categorías para el filtro
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(_productService.GetCategories());
        }

        // Escenario 2: productos de una categoría
        [HttpGet("category/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var result = _productService.GetByCategory(category);

            if (result == null)
            {
                return NotFound(new { message = "Categoría no encontrada" });
            }

            return Ok(result);
        }
    }
}
