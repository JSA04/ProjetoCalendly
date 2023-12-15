using Calendly.Api.Domain.DTOs;
using Calendly.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Calendly.Api.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{
    private readonly IServ _service = new Serv();

    [HttpGet("/ListEvents")]
    public IActionResult ListEvents() =>
        Ok(_service.ListEvents());

    [HttpGet("/FindEventById")]
    public IActionResult FindEventById(string uid)
    {
        IEventDto? eventDto = _service.FindEventById(uid);

        if (eventDto is not null) return Ok(eventDto);
        return NotFound("Não foi encontrado evento com esse UId.");
    }

    [HttpPost("/AddEvent")]
    public IActionResult AddEvent([FromBody] EventPostDto newEventDto)
        => Ok(_service.AddEvent(newEventDto));

    [HttpPut("/UpdateEvent")]
    public IActionResult UpdateEvent(string uIdEvent, [FromBody] EventPutDto newEventDto)
        => Ok(_service.UpdateEvent(uIdEvent, newEventDto));

    [HttpDelete("/DeleteEvent")]
    public IActionResult DeletedEvent(string uIdEvent)
        => Ok(_service.DeleteEvent(uIdEvent));
}
