using Calendly.Api.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Calendly.Api.Controller;

[ApiController]
[Route("/[controller]")]
public class Controller : ControllerBase
{
    private readonly Service.IService _service = new Service.Service ();

    [HttpGet("/ListEvents")]
    public List<EventDTO> ListEvents() => _service.ListEvents();

    [HttpGet("/FindEventById")]
    public EventDTO FindEventById(string uid) => _service.FindEventById(uid);

    [HttpPost("/AddEvent")]
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
        => _service.AddEvent(eventName, eventDuration, eventLocation, eventDescription);

    [HttpPut("/UpdateEvent")]
    public string UpdateEvent(string uIdEvent, [FromBody] EventDTOPut newEventDto)
        => _service.UpdateEvent(uIdEvent, newEventDto);
}
