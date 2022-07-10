using Interfaces;

namespace NotificationService;
public class NotificationService : INotificationService
{
        public void Execute(string message)  
        {  
            Console.WriteLine(message);  
        }
}
