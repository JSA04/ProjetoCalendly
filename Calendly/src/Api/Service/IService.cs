namespace Calendly.Api.Service;

public interface IService {
    public string ListEvents();
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription);
    public string UpdateEvent(string uid, string eventName, int eventDuration, string eventLocation, string eventDescription);
}