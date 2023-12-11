using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Service;

public interface IServ {
    public List<EventDto>? ListEvents();
    public EventDto? FindEventById(string uid);
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription);
    public string UpdateEvent(string eventUId, EventDtoPut newEventDto);
    public string DeleteEvent(string uid);
}