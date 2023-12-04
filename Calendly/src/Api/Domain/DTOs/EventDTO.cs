using System.Text.Json.Serialization;
using Calendly.Api.Domain.DAOs;
using MongoDB.Bson;

namespace Calendly.Api.Domain.DTOs;

public class EventDTO {
    [JsonIgnore]
    public ObjectId Id {get ; set;}
    public string UId {get ; set;}
    public string EventName {get ; set;}
    public int EventDuration {get ; set;}
    public string EventLocation {get ; set;}
    public string EventDescription {get ; set;}
    [JsonIgnore]
    public DateTime EventLastUpdateTime {get ; set;}
    [JsonIgnore]
    public DateTime EventCreationTime {get ; set;}
    
    
    public EventDTO (string name, int duration, string location, string description)
    {
        UId = Guid.NewGuid().ToString();
        EventName = name;
        EventDuration = duration;
        EventLocation = location;
        EventDescription = description;
        EventLastUpdateTime = DateTime.Now;
        EventCreationTime = DateTime.Now;
    }
    
    public EventDTO (EventDAO eventDao)
    {
        Id = eventDao.Id;
        UId = eventDao.UId;
        EventName = eventDao.EventName;
        EventDuration = eventDao.EventDuration;
        EventLocation = eventDao.EventLocation;
        EventDescription = eventDao.EventDescription;
        EventLastUpdateTime = eventDao.EventLastUpdateTime;
        EventCreationTime = eventDao.EventCreationTime;
    }
}