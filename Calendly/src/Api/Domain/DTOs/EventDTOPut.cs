using System.Text.Json.Serialization;

namespace Calendly.Api.Domain.DTOs;

public class EventDTOPut {
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