using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace Calendly.Api.Domain.DTOs;

public class EventDtoPut {
    [JsonIgnore]
    public ObjectId? Id {get ; set;}
    [JsonIgnore]
    public string? UId {get ; set;}
    public string? EventName {get ; set;}
    public int? EventDuration {get ; set;}
    public string? EventLocation {get ; set;}
    public string? EventDescription {get ; set;}
    [JsonIgnore]
    public DateTime? EventLastUpdateTime {get ; set;}
    [JsonIgnore]
    public DateTime? EventCreationTime {get ; set;}
}