using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using Calendly.Api.Repository;

namespace Calendly.Api.Service;

public class Serv : IServ
{
    private readonly IRepo _repository = new Repo();
    
    public List<EventDto> ListEvents ()
    {
        List<EventDto> events = new ();
        
        _repository.ListEvents().ForEach(
            eventDao => events.Add(new EventDto(eventDao))
        );
        
        return events;
    }

    public EventDto FindEventById(string uid)
    {
        EventDto eventDto = new EventDto(_repository.FindEventById(uid));

        return eventDto;
    }

    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription)
    {
        EventDto newEvent = new EventDto(eventName, eventDuration, eventLocation, eventDescription);
        bool result = _repository.AddEvent(newEvent);
        
        return result?"Criado com Sucesso":"Falha na Criação";
    }

    public string UpdateEvent(string eventUId, EventDtoPut newEventDto)
    {
        EventDto eventToUpdateDto = FindEventById(eventUId);

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

    public string DeleteEvent(string eventUId)
    {
        bool result = _repository.DeleteEvent(eventUId);
        
        return result?"Deletado com Sucesso":"Falha na Deleção";
    }

}
