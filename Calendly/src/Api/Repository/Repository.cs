using Calendly.Api.Models;
using MongoDB.Driver;

namespace Calendly.Api.Repository;

public class Repository : IRepository {
    private readonly IMongoCollection<Event> _infrastructure;
    
    public Repository ()
    {
        _infrastructure = Infrastructure.Infrastructure.GetInfrastructure();
    }

    public List<Event> ListEvents ()
    {
        var filter = Builders<Event>.Filter.Empty;
        return _infrastructure.Find(filter).ToList();
    }

    public bool AddEvent(Event e)
    {
        try
        {
            _infrastructure.InsertOne(e);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }

        return true;
    }

    public bool UpdateEvent(string uid, Event e)
    {
        try
        {
            var filter = Builders<Event>.Filter.Eq(ev => ev.UId, uid);
            var update = Builders<Event>.Update;

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