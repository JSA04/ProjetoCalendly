using System.Text;
using MongoDB.Driver;

namespace Calendly.Repository;

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

    public void AddEvent()
    {

    }
}