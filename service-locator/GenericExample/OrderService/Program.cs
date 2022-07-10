Console.WriteLine("Would you like to return or update an order?");
var userChoice = Console.ReadLine();
Console.WriteLine($"Order {userChoice}ed");
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);