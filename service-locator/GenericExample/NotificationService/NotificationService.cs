using Interfaces;

namespace NotificationService;
public class NotificationService : INotificationService
{
    public void Notify(string message)  
    {  
        Console.WriteLine(message);  
    }
}
