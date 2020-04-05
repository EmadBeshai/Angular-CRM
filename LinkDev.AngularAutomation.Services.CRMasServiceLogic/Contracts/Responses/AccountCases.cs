using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses
{
    [DataContract]
    public class AccountCases
    {
        [DataMember]
        public string ProcessingStatus { get; set; }
        [DataMember]
        public string ProcessingCode { get; set; }
        [DataMember]
        public string ProcessingMessage { get; set; }
        [DataMember]
        public List<AccountDetials> Accounts { get; set; }
       
    }

    [DataContract]
    public class AccountDetials
    {
        [DataMember]
        public string AccountID { get; set; }
        [DataMember]
        public string AccountName { get; set; }
    }
}
