using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Repository;

public interface IRepo {
    public List<EventDao> ListEvents();
    public EventDao FindEventById(string uid);
    public bool AddEvent(EventDto e);
    public bool UpdateEvent(string oldEventUId, EventDto newEventDto);
    public bool DeleteEvent(string uid);
}