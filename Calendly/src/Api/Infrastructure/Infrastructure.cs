using Calendly.Api.Models;
using MongoDB.Driver;

namespace Calendly.Api.Infrastructure;

public sealed class Infrastructure {
    
    private static IMongoCollection<Event>? _infrastructure;
    
    public static IMongoCollection<Event> GetInfrastructure ()
    {
        if (_infrastructure is null)
        {

            string mongoUri = "mongodb+srv://juan1234:juan1234@cluster0.ro1f7fh.mongodb.net/?retryWrites=true&w=majority";
            string mongoDb = "Calendly";
            string mongoCollection = "events";

            IMongoClient client = new MongoClient(mongoUri);
            IMongoDatabase db = client.GetDatabase(mongoDb);
            _infrastructure = db.GetCollection<Event>(name: mongoCollection);
        }
        
        return _infrastructure;
    }

}