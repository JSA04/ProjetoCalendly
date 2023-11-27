using MongoDB.Driver;
namespace Calendly.Infrastructure;

public sealed class Infrastructure {
    
    private static IMongoCollection<string>? _infrastructure;
    
    public static IMongoCollection<string> GetInfrastructure ()
    {
        if (_infrastructure is null)
        {
            string? mongoUri = Environment.GetEnvironmentVariable("MONGO_URI");
            string? mongoDb = Environment.GetEnvironmentVariable("MONGO_DATABASE");
            string? mongoCollection = Environment.GetEnvironmentVariable("MONGO_COLLECTION");
            Console.Write("MONGO URI: " + mongoUri);
            IMongoClient client = new MongoClient(mongoUri);
            IMongoDatabase db = client.GetDatabase(mongoDb);
            _infrastructure = db.GetCollection<string>(name: mongoCollection);
        }
        
        return _infrastructure;
    }
}