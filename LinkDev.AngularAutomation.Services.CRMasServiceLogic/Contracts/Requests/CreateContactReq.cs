using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Requests
{
    [DataContract]
    public class CreateContactReq
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        [Required]
        public string LastName { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [DataMember]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
