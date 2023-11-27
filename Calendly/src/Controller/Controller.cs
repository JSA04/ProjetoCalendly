using Microsoft.AspNetCore.Mvc;
namespace Calendly.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{

    
    private readonly Calendly.Service.Service _service = new();
    [HttpGet]
    public string? ListEvents() => _service.ListEvents();
}
