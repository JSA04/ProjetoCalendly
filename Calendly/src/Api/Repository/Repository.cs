using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using Calendly.Api.Infrastructure;
using MongoDB.Driver;

namespace Calendly.Api.Repository;

public class Repo : IRepo {
    private readonly IMongoCollection<EventDao> _infrastructure
        = Infra.GetInfrastructure();

    public List<EventDao> ListEvents ()
    {
        var filter = Builders<EventDao>.Filter.Empty;
        return _infrastructure.Find(filter).ToList();
    }

    public EventDao FindEventById(string uid)
    {

        var filter = Builders<EventDao>.Filter.Eq(ev => ev.UId, uid);
        return _infrastructure.Find(filter).First();

    }

    public bool AddEvent(EventDto e)
    {
        try
        {
            EventDao eDao = new EventDao(e);
            _infrastructure.InsertOne(eDao);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }

        return true;
    }

    public bool UpdateEvent(string oldEventId, EventDto newEventDto)
    {
        try
        {
            EventDao newEventDao = new EventDao(newEventDto);

            var filter = Builders<EventDao>.Filter.Eq(ev => ev.UId, oldEventId);
            _infrastructure.ReplaceOne(filter, newEventDao);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }

        return true;
    }

    public bool DeleteEvent(string uid)
    {
        try
        {
            var filter = Builders<EventDao>.Filter.Eq(ev => ev.UId, uid);

            if (_infrastructure.Find(filter).First() is null)
            {
                throw new MongoNotFoundException();
            }

            _infrastructure.DeleteOne(filter);
        }
        catch (MongoNotFoundException)
        {
            return false;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
        return true;
    }
}