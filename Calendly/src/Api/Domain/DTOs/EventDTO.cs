using MongoDB.Bson;

namespace Calendly.Api.Domain.DTOs;

public interface IEventDto
{
    public ObjectId? Id { get; set; }
    public string? UId { get; set; }
    public string EventName { get; set; }
    public int EventDuration { get; set; }
    public string EventLocation { get; set; }
    public DateTime? EventLastUpdateTime { get; set; }
    public DateTime? EventCreationTime { get; set; }
}
