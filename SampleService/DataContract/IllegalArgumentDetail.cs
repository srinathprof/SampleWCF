using System.Runtime.Serialization;

namespace SampleService
{
    [DataContract]
    public class IllegalArgumentDetail
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Details { get; set; }

        // Constructor with parameters for Message and Details
        public IllegalArgumentDetail(string message, string details)
        {
            Message = message;
            Details = details;
        }
    }
}
