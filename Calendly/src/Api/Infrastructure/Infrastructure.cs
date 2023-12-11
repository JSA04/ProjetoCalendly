using Calendly.Api.Domain.DAOs;
using MongoDB.Driver;

namespace Calendly.Api.Infrastructure;

public sealed class Infra {
    
    private static IMongoCollection<EventDao>? _infrastructure;
    
    public static IMongoCollection<EventDao> GetInfrastructure ()
    {
        if (_infrastructure is null)
        {

            string mongoUri = "mongodb+srv://juan1234:juan1234@cluster0.ro1f7fh.mongodb.net/?retryWrites=true&w=majority";
            string mongoDb = "Calendly";
            string mongoCollection = "events";

            IMongoClient client = new MongoClient(mongoUri);
            IMongoDatabase db = client.GetDatabase(mongoDb);
            _infrastructure = db.GetCollection<EventDao>(name: mongoCollection);
        }
        
        return _infrastructure;
    }

}