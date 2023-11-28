using MongoDB.Driver;

namespace Calendly.Repository;

public interface IRepository {
    public List<Event> ListEvents();
    public void AddEvent();
}