#pragma warning disable CS8766 // Nullability of reference types in return type doesn't match implicitly implemented member (possibly because of nullability attributes).
using System.Text.Json.Serialization;
using Calendly.Api.Domain.DAOs;
using MongoDB.Bson;

namespace Calendly.Api.Domain.DTOs;

/// Entrada de dados via PUT \\\
public class EventPutDto : IEventDto
{
    [JsonIgnore] public ObjectId? Id {get; set; }
    [JsonIgnore] public string? UId {get; set; }
    public string? EventName { get; set; }
    public int EventDuration { get; set; }
    public string? EventLocation { get; set; }
    [JsonIgnore] public DateTime? EventLastUpdateTime { get; set; }
    [JsonIgnore] public DateTime? EventCreationTime { get; set; }
}

/// Entrada de dados via POST \\\
public class EventPostDto : IEventDto
{
    [JsonIgnore] public ObjectId? Id {get; set; }
    [JsonIgnore] public string? UId {get; set; }
    public string EventName { get; set; }
    public int EventDuration { get; set; }
    public string EventLocation { get; set; }
    [JsonIgnore] public DateTime? EventLastUpdateTime { get; set; }
    [JsonIgnore] public DateTime? EventCreationTime { get; set; }
    
    // Metodx para Inicializacao do Id, Unique Id e Registro de Criacao \\\
    public EventPostDto(string eventName, int eventDuration, string eventLocation)
    {
        Id = ObjectId.GenerateNewId();
        UId = Guid.NewGuid().ToString();
        EventName = eventName;
        EventDuration = eventDuration;
        EventLocation = eventLocation;
        EventLastUpdateTime = DateTime.UtcNow;
        EventCreationTime = DateTime.UtcNow;
    }
}

/// Entrada de dados via GET \\\
public class EventGetDto : IEventDto
{
    [JsonIgnore] public ObjectId? Id {get; set; }
    public string? UId {get; set; }
    public string? EventName { get; set; }
    public int EventDuration { get; set; }
    public string? EventLocation { get; set; }
    [JsonIgnore] public DateTime? EventLastUpdateTime { get; set; }
    [JsonIgnore] public DateTime? EventCreationTime { get; set; }
    
    public EventGetDto (EventDao eventDao)
    {
        Id = eventDao.Id;
        UId = eventDao.UId;
        EventName = eventDao.EventName;
        EventDuration = (int) eventDao.EventDuration!;
        EventLocation = eventDao.EventLocation;
        EventLastUpdateTime = eventDao.EventLastUpdateTime;
        EventCreationTime = eventDao.EventCreationTime;
    }
}