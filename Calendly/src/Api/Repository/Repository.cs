using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using MongoDB.Driver;

namespace Calendly.Api.Repository;

public class Repository : IRepository {
    private readonly IMongoCollection<EventDAO> _infrastructure;
    
    public Repository ()
    {
        _infrastructure = Infrastructure.Infrastructure.GetInfrastructure();
    }

    public List<EventDAO> ListEvents ()
    {
        var filter = Builders<EventDAO>.Filter.Empty;
        return _infrastructure.Find(filter).ToList();
    }

    public EventDAO FindEventById(string uid)
    {

        var filter = Builders<EventDAO>.Filter.Eq(ev => ev.UId, uid);
        return _infrastructure.Find(filter).First();

    }

    public bool AddEvent(EventDTO e)
    {
        try
        {
            EventDAO eDao = new EventDAO(e);
            _infrastructure.InsertOne(eDao);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }

        return true;
    }

    public bool UpdateEvent(string oldEventId, EventDTO newEventDto)
    {
        try
        {
            EventDAO newEventDao = new EventDAO(newEventDto);

            var filter = Builders<EventDAO>.Filter.Eq(ev => ev.UId, oldEventId);
            _infrastructure.ReplaceOne(filter, newEventDao);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }

        return true;
    }
}