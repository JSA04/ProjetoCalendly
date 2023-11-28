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
}