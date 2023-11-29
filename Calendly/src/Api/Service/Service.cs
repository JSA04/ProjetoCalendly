using Calendly.Api.Models;
using Calendly.Api.Repository;
using MongoDB.Bson;

namespace Calendly.Api.Service;

public class Service : IService
{
    private readonly IRepository _repository;

    public Service () => _repository = new Repository.Repository();
    
    public string ListEvents ()
    {
        List<Event> events = _repository.ListEvents();
        return events.ToJson();
    }

    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        Event newEvent = new Event(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.AddEvent(newEvent);
        
        return result?"Criado com Sucesso":"Falha na Criação";
    }

    public string UpdateEvent(string uid, string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        Event updatedEvent = new Event(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.UpdateEvent(uid, updatedEvent);

        return result?"Atualizado com Sucesso":"Falha na Atualizacao";
    }
}
