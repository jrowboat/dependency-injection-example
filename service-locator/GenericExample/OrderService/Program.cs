using NotificationService;
using Interfaces;

Console.WriteLine("Would you like to return or update an order?");
var userChoice = Console.ReadLine();
INotificationService service = new NotificationService.NotificationService();
service.Execute("Customer notified");
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);