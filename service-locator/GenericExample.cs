using System;  
using System.Collections.Generic;  
using System.Text;  
namespace ServiceLocator.GenericExample
{  
    public interface IReturnService
    {  
        void Execute();  
    }  
  
    public class ReturnService : IReturnService
    {  
        public void Execute()  
        {  
            Console.WriteLine("Order service called.");  
        }  
    }  
  
    public interface IUpdateService  
    {  
        void Execute();  
    }  
  
    public class UpdateService : IUpdateService  
    {  
        public void Execute()  
        {  
            Console.WriteLine("Update service called.");  
        }  
    }  
  
    public interface IService  
    {  
        T GetService<T>();  
    }  
    public class ServiceLocator : IService  
    {  
        public Dictionary<object, object> serviceContainer = null;  
        public ServiceLocator()  
        {  
            serviceContainer = new Dictionary<object, object>();  
            serviceContainer.Add(typeof(IReturnService), new ReturnService());  
            serviceContainer.Add(typeof(IUpdateService), new UpdateService());  
        }  
        public T GetService<T>()  
        {  
            try  
            {  
                return (T)serviceContainer[typeof(T)];  
            }  
            catch (Exception ex)  
            {  
                throw new NotImplementedException("Service not available.");  
            }  
        }  
    }  
    class Program  
    {  
        static void Main(string[] args)  
         {  
            ServiceLocator locator = new ServiceLocator();  
            IReturnService returnSservice =  locator.GetService<IReturnService>();  
            returnSservice.Execute();  
  
            IUpdateService updateService = locator.GetService<IUpdateService>();  
            updateService.Execute();  
  
           Console.ReadLine();  
         }  
    }  
} 