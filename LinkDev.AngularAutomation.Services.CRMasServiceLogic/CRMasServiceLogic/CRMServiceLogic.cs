using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Requests;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses;
using LinkDev.AngularAutomation.Services.DataContracts;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.CRMasServiceLogic
{
    public  class CrmServiceLogic: ICrmServiceLogic
    {
        public ICrmConnection CrmConnection { get; }

        

        public CrmServiceLogic(ICrmConnection crmConnection)
        {
            CrmConnection = crmConnection;
        }

        public CreateRecordResponse CreateContact(CreateContactReq CreateContactReq)
        {
            Entity contact = new Entity(Contact.EntityLogicalName);
            contact[Contact.Fields.FirstName] = CreateContactReq.FirstName;
            contact[Contact.Fields.LastName] = CreateContactReq.LastName;
            contact[Contact.Fields.Email] = CreateContactReq.Email;
            contact[Contact.Fields.BusinessPhone] = CreateContactReq.PhoneNumber;

            var ContactID = CrmConnection.Create(contact);
            
            return new CreateRecordResponse
            {
                ProcessingCode = "200",
                ProcessingMessage = "success",
                ProcessingStatus = "success",
                EntityLogicalName =Contact.EntityLogicalName,
                RecordID = ContactID.ToString()
            };
        }
    }
}
