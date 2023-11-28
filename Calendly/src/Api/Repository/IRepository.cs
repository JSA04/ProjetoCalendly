using Calendly.Api.Models;

namespace Calendly.Api.Repository;

public interface IRepository {
    public List<Event> ListEvents();
    public bool AddEvent(Event e);
}