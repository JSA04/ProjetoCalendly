using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using Calendly.Api.Repository;
using MongoDB.Bson;

namespace Calendly.Api.Service;

public class Service : IService
{
    private readonly IRepository _repository;

    public Service () => _repository = new Repository.Repository();
    
    public List<EventDTO> ListEvents ()
    {
        List<EventDAO> eventsDaos = _repository.ListEvents();
        List<EventDTO> events = new ();

        foreach (var eventDao in eventsDaos)
        {
            events.Add(new EventDTO(eventDao));
        }

        return events;
    }

    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        EventDTO newEvent = new EventDTO(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.AddEvent(newEvent);
        
        return result?"Criado com Sucesso":"Falha na Criação";
    }

    public string UpdateEvent(string uid, string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        EventDTO updatedEvent = new EventDTO(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.UpdateEvent(uid, updatedEvent);

        return result?"Atualizado com Sucesso":"Falha na Atualizacao";
    }
}
