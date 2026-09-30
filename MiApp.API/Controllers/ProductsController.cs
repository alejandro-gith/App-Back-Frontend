using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MiApp.Domain.Dtos;
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

        [HttpGet]
        public ActionResult<List<ProductResponseDto>> GetAll()
        {
            return Ok(_productService.GetAll());
        }
    }
}