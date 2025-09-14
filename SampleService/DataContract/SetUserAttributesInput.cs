using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleService
{
    public class SetUserAttributesInput
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
}