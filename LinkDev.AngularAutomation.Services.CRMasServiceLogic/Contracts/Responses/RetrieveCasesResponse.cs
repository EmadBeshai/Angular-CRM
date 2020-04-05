using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses
{
    [DataContract]
    public class RetrieveCasesResponse
    {
        [DataMember]
        public string ProcessingStatus { get; set; }
        [DataMember]
        public string ProcessingCode { get; set; }
        [DataMember]
        public string ProcessingMessage { get; set; }
        [DataMember]
        public List<RelatedCases> Cases { get; set; }
    }

    [DataContract]
    public class RelatedCases
    {
        [DataMember]
        public string CaseTitle { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string CreatedOn { get; set; }
    }
}
