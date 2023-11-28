namespace Calendly.Service;

public interface IService {
    public string ListEvents();
    public string AddEvent(string eventName, int eventDuration, string eventLocation, string eventDescription);
    
}