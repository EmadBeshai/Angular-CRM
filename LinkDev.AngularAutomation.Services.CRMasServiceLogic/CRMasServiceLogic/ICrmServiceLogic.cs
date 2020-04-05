using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Requests;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.CRMasServiceLogic
{
    public interface ICrmServiceLogic
    {
        ICrmConnection CrmConnection { get; }

        CreateRecordResponse CreateContact(CreateContactReq CreateContactReq);
        AccountCases GetAccountsWithCases();
        RetrieveCasesResponse GetAccountRelatedCases(string AccountID);
    }
}
