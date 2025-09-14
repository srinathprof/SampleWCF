using SamplePfw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleService
{
    [LoggingBehaviour]
    public class SampleService : ISampleService
    {

        private IDataAccess _dataAccess;

        public IDataAccess DataAccess
        {
            get => _dataAccess;
            set => _dataAccess = value ?? throw new ArgumentNullException(nameof(DataAccess));
        }
        public GetUserAttributesOutput GetUserAttributes(GetUserAttributesInput userAttributes)
        {
            if(userAttributes == null) throw new ArgumentNullException(nameof(userAttributes));
            GetUserAttributesOutput userAttributesOutput = new GetUserAttributesOutput();
            DataAccess.RetrieveUserAttributes(userAttributes);
            return userAttributesOutput;
        }

        public SetUserAttributesOutput SetUserAttributes(SetUserAttributesInput setUserAttributes)
        {
            if (setUserAttributes == null)
                throw new ArgumentNullException(nameof(setUserAttributes));


            SetUserAttributesOutput output = new SetUserAttributesOutput();
            DataAccess.SaveUserAttributes(setUserAttributes);

            return output;
        }
    }
}
