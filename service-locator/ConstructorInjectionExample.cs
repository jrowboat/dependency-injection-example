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

        IServiceLocator _locator;
        static void Main(ServiceLocator locator)  
         {
            _locator = locator;
         }  

        ExecuteUpdate(){
            var updateService = _locator.GetService(UpdateService);
            updateService.Execute();
        }
    }  
} 