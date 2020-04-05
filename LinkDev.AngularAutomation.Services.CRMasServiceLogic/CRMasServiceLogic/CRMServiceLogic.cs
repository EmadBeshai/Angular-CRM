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


        public AccountCases GetAccountsWithCases()
        {
            try
            {
                string fetch = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>" +
                               "<entity name='account'>" +
                               "<attribute name='name' />" +
                               "<attribute name='primarycontactid' />" +
                               "<attribute name='telephone1' />" +
                               "<attribute name='accountid' />" +
                               "<order attribute='name' descending='false' />" +
                               "<link-entity name='incident' from='customerid' to='accountid' link-type='inner' alias='ae' />" +
                               "</entity>" +
                               "</fetch>";

                FetchExpression qe = new FetchExpression(fetch);
                var Accounts = CrmConnection.RetrieveMultiple(qe).Entities;

                List<AccountDetials> accounts = new List<AccountDetials>();
                foreach (var acc in Accounts)
                {
                    var targetAccount = new AccountDetials
                    {
                        AccountID = acc.Id.ToString(),
                        AccountName = acc.Attributes["name"].ToString()
                    };
                    accounts.Add(targetAccount);
                }
                return new AccountCases
                {
                    ProcessingMessage = "Accounts Retrieved Successfully",
                    ProcessingCode = "200",
                    ProcessingStatus = "success",
                    Accounts = accounts
                };
            }
            catch (Exception ex)
            {
                return new AccountCases
                {
                    ProcessingMessage = ex.Message,
                    ProcessingCode = "400",
                    ProcessingStatus = "error",
                    Accounts = null
                };
            }
        }

        public RetrieveCasesResponse GetAccountRelatedCases(string AccountID)
        {
            try
            {
                AccountID = AccountID.Replace("{", "");
                AccountID = AccountID.Replace("}", "");
                string fetch= @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
                               "<entity name='incident'>" +
                               "<attribute name='title' />" +
                               "<attribute name='ticketnumber' />" +
                               "<attribute name='createdon' />" +
                               "<attribute name='incidentid' />" +
                               "<attribute name='caseorigincode' />" +
                               "<order attribute='title' descending='false' />" +
                               "<link-entity name='account' from='accountid' to='customerid' link-type='inner' alias='ai'>" +
                               "<filter type='and'>" +
                               "<condition attribute='accountid' operator='eq' uiname='A. Datum' uitype='account' value='"+ AccountID + "' />" +
                               "</filter>" +
                               "</link-entity>" +
                               "</entity>" +
                               "</fetch>";
                FetchExpression qe = new FetchExpression(fetch);
                List<RelatedCases> AccountCases = new List<RelatedCases>();
                var relatedCases = CrmConnection.RetrieveMultiple(qe).Entities;
                foreach(var c in relatedCases){
                    AccountCases.Add(new RelatedCases
                    {
                        CaseTitle=c.Attributes["title"].ToString(),
                        CaseNumber=c.Attributes["ticketnumber"].ToString(),
                        CreatedOn=c.Attributes["createdon"].ToString()
                    });
                }
                return new RetrieveCasesResponse
                {
                    ProcessingMessage = "Cases have been Retrieved Successfully",
                    ProcessingStatus = "success",
                    ProcessingCode = "200",
                    Cases = AccountCases
                };
            }
            catch (Exception ex)
            {
                return new RetrieveCasesResponse
                {
                    ProcessingMessage = ex.Message,
                    ProcessingStatus = "error",
                    ProcessingCode = "400",
                    Cases = null
                };
            }
        }
    }
}
