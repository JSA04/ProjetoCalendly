using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Service;

public interface IService {
    public List<EventDTO> ListEvents();
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription);
    public string UpdateEvent(string uid, EventDTO eventDto);
}