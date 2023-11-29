using System.Xml;
using MongoDB.Bson;

namespace Calendly.Api.Models;

public class Event {
    public ObjectId Id {get ; set;}
    public string UId {get ; set;}
    public string EventName {get ; set;}
    public int EventDuration {get ; set;}
    public string EventLocation {get ; set;}
    public string EventDescription {get ; set;}
    
    public Event (string name, int duration, string location, string description)
    {
        Id = ObjectId.GenerateNewId();
        UId = Guid.NewGuid().ToString();
        EventName = name;
        EventDuration = duration;
        EventLocation = location;
        EventDescription = description;
    }


    public override string ToString() =>
        $"{{\n" +
        $"\t\"event_id\": \"{Id.ToString()}\"\n" +
        $"\t\"event_id\": \"{UId}\"\n" +
        $"\t\"event_name\": \"{EventName}\"\n" +
        $"\t\"event_duration\": {EventDuration}\n" +
        $"\t\"event_location\": \"{EventLocation}\"\n" +
        $"\t\"event_description\": \"{EventDescription}\"" +
        $"\n}}";
}