using Microsoft.AspNetCore.Mvc;

namespace Viper.Api.Controllers;

/// <summary>Проверка, что API живо. Десктоп может дёргать его при старте.</summary>
[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "ok", time = DateTime.UtcNow });
}
