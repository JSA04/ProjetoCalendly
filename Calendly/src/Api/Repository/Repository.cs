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

    public bool UpdateEvent(string uid, EventDTO newEventDto)
    {
        try
        {
            var filter = Builders<EventDAO>.Filter.Eq(ev => ev.UId, uid);
            var update = Builders<EventDAO>.Update;

            if (newEventDto.EventName.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventName, newEventDto.EventName));

            if (newEventDto.EventDuration > 0)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventDuration, newEventDto.EventDuration));

            if (newEventDto.EventLocation.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventLocation, newEventDto.EventLocation));

            if (newEventDto.EventDescription.Trim() != String.Empty)
                _infrastructure.UpdateOne(filter, update.Set(oldEvent => oldEvent.EventDescription, newEventDto.EventDescription));

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }

        return true;


    }
}