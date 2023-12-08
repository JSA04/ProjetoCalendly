using Calendly.Api.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Calendly.Api.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{
    private readonly Service.IService _service = new Service.Service ();

    [HttpGet("/ListEvents")]
    public IActionResult ListEvents() =>
        Ok(_service.ListEvents());

    [HttpGet("/FindEventById")]
    public IActionResult FindEventById(string uid)
    {
        EventDTO? eventDto = _service.FindEventById(uid);
        if (eventDto is null)
        {
            return NotFound("Não foi encontrado evento com esse UId.");
        }

        return Ok(eventDto);
    }

    [HttpPost("/AddEvent")]
    public IActionResult AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
        => Ok(_service.AddEvent(eventName, eventDuration, eventLocation, eventDescription));

    [HttpPut("/UpdateEvent")]
    public IActionResult UpdateEvent(string uIdEvent, [FromBody] EventDTOPut newEventDto)
        => Ok(_service.UpdateEvent(uIdEvent, newEventDto));

    [HttpDelete("/DeleteEvent")]
    public IActionResult DeletedEvent(string uIdEvent)
        => Ok(_service.DeleteEvent(uIdEvent));
}
