using Microsoft.AspNetCore.Mvc;

namespace MiApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult CheckHealth()
        {
            return Ok(new
            {
                status = "Backend funcionando correctamente",
                timestamp = DateTime.Now
            });
        }
    }
}