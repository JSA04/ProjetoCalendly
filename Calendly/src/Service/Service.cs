using System.Text;
using MongoDB.Bson;

namespace Calendly.Service;

public class Service : IService
{
    private readonly Repository.IRepository _repository;

    public Service () => _repository = new Repository.Repository ();
    
    public string ListEvents ()
    {
        List<Event> events = _repository.ListEvents();
        return events.ToJson();
    }

    
}
