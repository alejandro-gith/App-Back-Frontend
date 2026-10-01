using Microsoft.AspNetCore.Mvc;
using MiApp.Service.Interfaces;

namespace MiApp.API.Controllers;

[ApiController]
[Route("api/carts")]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public IActionResult GetAllCarts()
    {
        var carts = _cartService.GetAllCarts();

        return Ok(carts);
    }
}