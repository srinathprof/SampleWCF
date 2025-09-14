using System;
using System.Data;
using System.Data.SqlClient;
using Unity;
using Unity.Lifetime;

namespace SampleService.Startup
{
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        public static IUnityContainer RegisterComponents()
        {
            _container = new UnityContainer();

            // Register IDbConnection with a transient lifetime  
            _container.RegisterType<IDbConnection>(
                new TransientLifetimeManager(),
                factory => new SqlConnection("YourConnectionStringHere"));

            // Register other dependencies  
            _container.RegisterType<IDataAccess, DataAccess>();

            return _container;
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("The Unity container has not been configured. Call RegisterComponents first.");
            }
            return _container;
        }
    }
}
