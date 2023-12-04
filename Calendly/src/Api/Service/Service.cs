using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using Calendly.Api.Repository;

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

    public EventDTO FindEventById(string uid)
    {
        EventDTO eventDto = new EventDTO(_repository.FindEventById(uid));

        return eventDto;
    }

    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        EventDTO newEvent = new EventDTO(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.AddEvent(newEvent);
        
        return result?"Criado com Sucesso":"Falha na Criação";
    }

    public string UpdateEvent(string eventUId, EventDTOPut newEventDto)
    {
        EventDTO eventToUpdateDto = FindEventById(eventUId);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (eventToUpdateDto is null)
        {
            return "Evento não encontrado";
        }

        foreach (var property in newEventDto.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(newEventDto);

            if (property.Name == "EventLastUpdateTime")
            {
                eventToUpdateDto.GetType().GetProperty(property.Name)!.SetValue(eventToUpdateDto, DateTime.Now);
            } else if (propertyValue != null)
            {
                eventToUpdateDto.GetType().GetProperty(property.Name)!.SetValue(eventToUpdateDto, propertyValue);
            }
        }

        bool result = _repository.UpdateEvent(eventUId, eventToUpdateDto);

        return result?"Atualizado com Sucesso":"Falha na Atualizacao";
    }
}
