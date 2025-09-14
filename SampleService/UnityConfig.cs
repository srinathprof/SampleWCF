using System;
using System.Data;
using System.Data.SqlClient;
using Unity;
using Unity.Lifetime;
using SampleService; // Ensure this namespace is included

namespace SampleService.Startup
{
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        public static IUnityContainer RegisterComponents()
        {
            _container = new UnityContainer();

            // Register IDbConnection with a transient lifetime using RegisterFactory
            _container.RegisterFactory<IDbConnection>(c => new SqlConnection("SQL Connection String"), new TransientLifetimeManager());

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
