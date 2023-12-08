using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;

namespace Calendly.Api.Repository;

public interface IRepository {
    public List<EventDAO> ListEvents();
    public EventDAO FindEventById(string uid);
    public bool AddEvent(EventDTO e);
    public bool UpdateEvent(string oldEventUId, EventDTO newEventDto);
    public bool DeleteEvent(string uid);
}