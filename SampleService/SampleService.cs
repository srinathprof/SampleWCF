using SamplePfw;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Unity;

namespace SampleService
{
    [LoggingBehaviour]
    public class SampleService : ISampleService
    {

        private readonly IUnityContainer _container;
        public SampleService()
        {
            // Create / resolve Unity manually
            _container = new UnityContainer();
            _container.RegisterFactory<IDbConnection>(c => new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SRINATHTHANGARATHINA\\Documents\\CustomisationDB.mdf;Integrated Security=True;Connect Timeout=30"), new Unity.Lifetime.TransientLifetimeManager());
            _container.RegisterType<IDataAccess, DataAccess>();
        }

        private IDataAccess _dataAccess;

        public IDataAccess DataAccess
        {
            get
            { return _container.Resolve<IDataAccess>(); }
        }
        public GetUserAttributesOutput GetUserAttributes(GetUserAttributesInput userAttributes)
        {
            if(userAttributes == null) throw new ArgumentNullException(nameof(userAttributes));
            GetUserAttributesOutput userAttributesOutput = new GetUserAttributesOutput();
            return DataAccess.RetrieveUserAttributes(userAttributes);
            
        }

        public SetUserAttributesOutput SetUserAttributes(SetUserAttributesInput setUserAttributes)
        {
            if (setUserAttributes == null)
                throw new ArgumentNullException(nameof(setUserAttributes));


            SetUserAttributesOutput output = new SetUserAttributesOutput();
            return DataAccess.SaveUserAttributes(setUserAttributes);

           
        }
    }
}
