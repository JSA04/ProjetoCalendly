using Calendly.Api.Domain.DTOs;
using MongoDB.Bson;

namespace Calendly.Api.Domain.DAOs;

public class EventDao {
    
    public ObjectId Id {get ; set;}
    public string UId {get ; set;}
    public string EventName {get ; set;}
    public int EventDuration {get ; set;}
    public string EventLocation {get ; set;}
    public string EventDescription {get ; set;}
    public DateTime EventLastUpdateTime {get ; set;}
    public DateTime EventCreationTime {get ; set;}
    
    public EventDao (string name, int duration, string location, string description)
    {
        Id = ObjectId.GenerateNewId();
        UId = Guid.NewGuid().ToString();
        EventName = name;
        EventDuration = duration;
        EventLocation = location;
        EventDescription = description;
        EventLastUpdateTime = DateTime.Now;
        EventCreationTime = DateTime.Now;
    }
    
    public EventDao (EventDto eventDto)
    {
        Id = eventDto.Id;
        UId = eventDto.UId;
        EventName = eventDto.EventName;
        EventDuration = eventDto.EventDuration;
        EventLocation = eventDto.EventLocation;
        EventDescription = eventDto.EventDescription;
        EventLastUpdateTime = eventDto.EventLastUpdateTime;
        EventCreationTime = eventDto.EventCreationTime;
    }
}