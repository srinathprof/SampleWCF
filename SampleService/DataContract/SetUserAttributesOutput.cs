using System.Runtime.Serialization;

namespace SampleService
{
    [DataContract]
    public class SetUserAttributesOutput
    {
        [DataMember]
        public int Status { get; set; }
    }
}