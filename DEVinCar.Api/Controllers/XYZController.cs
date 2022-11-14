using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/xyz")]
public class XYZController : ControllerBase
{

    private readonly ILogger<XYZController> _logger;

    public XYZController(ILogger<XYZController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok();
    }
}
