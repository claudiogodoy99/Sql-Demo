using Microsoft.AspNetCore.Mvc;

namespace pocSql.Controllers;

[ApiController]
[Route("[controller]")]
public class ExemploController : ControllerBase
{
    public readonly ExemploRepository _exemploRepository;
    public ExemploController(ExemploRepository exemploRepository)
    {
        _exemploRepository = exemploRepository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        _exemploRepository.AlgumaOperacao();
        return Ok();
    }
}
