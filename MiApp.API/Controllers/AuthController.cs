using Microsoft.AspNetCore.Mvc;
using MiApp.Domain.Dtos;
using MiApp.Service.Interfaces;

namespace MiApp.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            var result = _authService.Login(request);

            if (result == null)
            {
                // Escenario 2: Retornar 401 Unauthorized con el mensaje requerido
                return Unauthorized(new { message = "Usuario o contraseña inválidos" });
            }

            // Escenario 1: Retornar 200 OK con el token y datos mapeados
            return Ok(result);
        }
    }
}