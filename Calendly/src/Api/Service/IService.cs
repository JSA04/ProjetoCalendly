using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Service;

public interface IService {
    public List<EventDTO> ListEvents();
    public EventDTO FindEventById(string uid);
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription);
    public string UpdateEvent(string eventUId, EventDTOPut newEventDto);
}