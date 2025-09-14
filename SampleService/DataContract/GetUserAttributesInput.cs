using System.Runtime.Serialization;

namespace SampleService
{
    [DataContract]
    public class GetUserAttributesInput
    {
        [DataMember]
        public string CustomerNumber { get; set; }
    }
}
