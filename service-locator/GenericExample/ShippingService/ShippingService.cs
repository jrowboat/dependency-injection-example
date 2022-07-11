using Interfaces;

namespace ShippingService;
public class ShippingService : IShippingService
{
    public void Ship(string message)  
    {  
        Console.WriteLine(message);  
    }
}
