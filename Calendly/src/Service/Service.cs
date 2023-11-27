namespace Calendly.Service;

public class Service
{
    private readonly Calendly.Repository.Repository _repository; 
    
    public Service () => _repository = new ();
    
    public string? ListEvents () 
    {
        return _repository.ListEvents().ToString();
    }
}
