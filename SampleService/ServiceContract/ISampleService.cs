using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleService
{
    
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        [FaultContract(typeof(IllegalArgumentDetail))]
        [FaultContract(typeof(IllegalDataFoundDetail))]
        GetUserAttributesOutput GetUserAttributes(GetUserAttributesInput userAttributes);

        [OperationContract]
        [FaultContract(typeof(IllegalArgumentDetail))]
        [FaultContract(typeof(IllegalDataFoundDetail))]
        SetUserAttributesOutput SetUserAttributes(SetUserAttributesInput userAttributes);

        
    }

   
}
