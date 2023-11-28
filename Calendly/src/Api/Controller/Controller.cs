using Microsoft.AspNetCore.Mvc;
namespace Calendly.Api.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{
    private readonly Service.IService _service = new Service.Service ();

    [HttpGet("/ListEvents")] public string ListEvents() => _service.ListEvents();
    [HttpPost("/AddEvent")] public string AddEvent()
        => _service.AddEvent();
}
