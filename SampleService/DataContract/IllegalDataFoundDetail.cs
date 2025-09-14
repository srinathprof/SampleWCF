using System.Runtime.Serialization;

namespace SampleService
{
    [DataContract]
    public class IllegalDataFoundDetail
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ErrorCode { get; set; }

        public IllegalDataFoundDetail(string message, string errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
