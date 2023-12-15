using Calendly.Api.Domain.DAOs;
using Calendly.Api.Domain.DTOs;
using Calendly.Api.Repository;

namespace Calendly.Api.Service;

public class Serv : IServ
{
    private readonly IRepo _repository = new Repo();
    
    public List<EventGetDto> ListEvents ()
    {
        List<EventGetDto> events = new ();
        
        _repository.ListEvents().ForEach(
            eventDao => events.Add(new EventGetDto(eventDao))
        );
        
        return events;
    }

    public EventGetDto? FindEventById(string uid)
    {
        EventDao? eventDaoFound = _repository.FindEventById(uid);
        return eventDaoFound is not null ? new EventGetDto(eventDaoFound) : null;
    }

    public string AddEvent(EventPostDto newEventDto)
    {
        if (newEventDto.EventDuration <= 0) return "Deve-se inserir a duração do Evento!";

        IEventDto newEvent = new EventPostDto(
            eventName: newEventDto.EventName,
            eventDuration: newEventDto.EventDuration,
            eventLocation: newEventDto.EventLocation
        );

        bool result = _repository.AddEvent(newEvent);

        return result?"Criado com Sucesso":"Falha na Criação";
    }

    public string UpdateEvent(string eventUId, EventPutDto newEventDto)
    {
        IEventDto? eventToUpdateDto = FindEventById(eventUId);

        if (eventToUpdateDto is null) return "Evento não encontrado";
        if (newEventDto.EventDuration <= 0) return "Deve-se inserir a duração do Evento!";

        foreach (var property in newEventDto.GetType().GetProperties())
        {
            var propertyValue = property.GetValue(newEventDto);
            if (propertyValue != null) eventToUpdateDto.GetType().GetProperty(property.Name)!
                .SetValue(eventToUpdateDto, propertyValue);
        }

        eventToUpdateDto.EventLastUpdateTime = DateTime.UtcNow;

        bool result = _repository.UpdateEvent(eventUId, eventToUpdateDto);

        return result?"Atualizado com Sucesso":"Falha na Atualizacao";
    }

    public string DeleteEvent(string eventUId)
    {

        IEventDto? eventToDeleteDto = FindEventById(eventUId);

        if (eventToDeleteDto is null) return "Evento não encontrado";

        bool result = _repository.DeleteEvent(eventUId);
        return result?"Deletado com Sucesso":"Falha na Deleção";
    }
}
