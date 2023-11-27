namespace Calendly;

public class Event {
    private string Name {get ; set;}
    private int Duration {get ; set;}
    private string Location {get ; set;}
    private string Description {get ; set;}
    
    public Event (string name, int duration, string location, string description)
    {
        Name = name;
        Duration = duration;
        Location = location;
        Description = description;
    } 
}