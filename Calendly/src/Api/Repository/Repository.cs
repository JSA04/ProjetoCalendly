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

    public bool UpdateEvent(string uid, EventDTO e)
    {
        try
        {
            var filter = Builders<EventDAO>.Filter.Eq(ev => ev.UId, uid);
            var update = Builders<EventDAO>.Update;

            if (e.EventName.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventName, e.EventName));

            if (e.EventDuration <= 0)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventDuration, e.EventDuration));

            if (e.EventLocation.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventLocation, e.EventLocation));

            if (e.EventDescription.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventDescription, e.EventDescription));

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }

        return true;


    }
}