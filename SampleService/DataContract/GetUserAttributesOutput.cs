using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleService
{
    [DataContract]
    public class GetUserAttributesOutput
    {
        [DataMember]
        public string StartPage { get; set; }

        [DataMember]
        public string ThemeChosen { get; set; }

        [DataMember]
        public string MemberGreeting { get; set; }

        [DataMember]
        public int CustomerOnboardingStatus { get; set; }

        [DataMember]
        public IList<CustomAccountDetails> CustomAccounts { get; set; }
        }

    [DataContract]
    public class CustomAccountDetails
    {
        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string AccountDescription { get; set; }
    }
}

  

