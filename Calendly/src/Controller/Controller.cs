using Microsoft.AspNetCore.Mvc;
namespace Calendly.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{
    private readonly Service.IService _service = new Service.Service ();

    [HttpGet("/ListEvents")] public string ListEvents() => _service.ListEvents();
}
