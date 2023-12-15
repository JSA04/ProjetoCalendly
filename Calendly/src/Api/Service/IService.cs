using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Service;

public interface IServ {
    public List<EventGetDto>? ListEvents();
    public EventGetDto? FindEventById(string uid);
    public string AddEvent(EventPostDto newEventDto);
    public string UpdateEvent(string eventUId, EventPutDto newEventDto);
    public string DeleteEvent(string uid);
}