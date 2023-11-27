using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Calendly.Repository;

public class Repository {
    private readonly IMongoCollection<string> _infrastructure;
    
    public Repository () => _infrastructure = Infrastructure.Infrastructure.GetInfrastructure();

    public IMongoQueryable ListEvents ()
    {
        return _infrastructure.AsQueryable();
    }
}