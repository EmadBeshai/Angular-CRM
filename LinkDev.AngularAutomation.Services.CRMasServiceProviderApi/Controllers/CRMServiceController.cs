using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Requests;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses;
using LinkDev.AngularAutomation.Services.CRMasServiceLogic.CRMasServiceLogic;
using LinkDev.AngularAutomation.Services.CRMasServiceProviderApi.Helpers;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LinkDev.AngularAutomation.Services.CRMasServiceProviderApi.Controllers
{
    public class CRMServiceController : ApiController
    {
        private readonly ICrmServiceLogic _crmServiceLogic;
        public ICrmConnection CrmConnection => _crmServiceLogic.CrmConnection;
        public CRMServiceController(ICrmServiceLogic crmServiceLogic)
        {
            _crmServiceLogic = crmServiceLogic;
        }

        
        [HttpPost]
        [Route("api/CRMService/CreateContact")]
        [ResponseType(typeof(CreateRecordResponse))]
        [SwaggerResponse(HttpStatusCode.OK, "Retrieves or create a case  from CRM", typeof(CreateRecordResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request", typeof(CreateRecordResponse))]
        public HttpResponseMessage CreateContact(CreateContactReq CreateContactReq)
        {
           
            if (ModelState.IsValid)
            {
                return _crmServiceLogic.CreateContact(CreateContactReq).HandleResponses(Request);
            }
            else
            {
                var Errors = ModelState.Keys.Where(i => ModelState[i].Errors.Count > 0)
.Select(k => new KeyValuePair<string, string>(k, ModelState[k].Errors.First().ErrorMessage)).ToList();
                return Request.CreateResponse<CreateRecordResponse>(new CreateRecordResponse
                {
                    ProcessingStatus = ProcessStatusEnum.Error.ToString(),
                    ProcessingCode = "400",
                    ProcessingMessage = Errors.FirstOrDefault().Value.ToString()

                });
            }
        }


        [HttpGet]
        [Route("api/CRMService/GetAccountWithCases")]
        [ResponseType(typeof(CreateRecordResponse))]
        [SwaggerResponse(HttpStatusCode.OK, "Retrieves Accounts  from CRM", typeof(AccountCases))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request", typeof(AccountCases))]
        public HttpResponseMessage GetAccountWithCases()
        {

            if (ModelState.IsValid)
            {
                return _crmServiceLogic.GetAccountsWithCases().HandleResponses(Request);
            }
            else
            {
                var Errors = ModelState.Keys.Where(i => ModelState[i].Errors.Count > 0)
.Select(k => new KeyValuePair<string, string>(k, ModelState[k].Errors.First().ErrorMessage)).ToList();
                return Request.CreateResponse<AccountCases>(new AccountCases
                {
                    ProcessingStatus = ProcessStatusEnum.Error.ToString(),
                    ProcessingCode = "400",
                    ProcessingMessage = Errors.FirstOrDefault().Value.ToString()

                });
            }
        }


        [HttpGet]
        [Route("api/CRMService/GetCasesRelatedtoAccount")]
        [ResponseType(typeof(CreateRecordResponse))]
        [SwaggerResponse(HttpStatusCode.OK, "Retrieves Accounts  from CRM", typeof(RetrieveCasesResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request", typeof(RetrieveCasesResponse))]
        public HttpResponseMessage GetCasesRelatedtoAccount(string AccountID)
        {

            if (ModelState.IsValid)
            {
                return _crmServiceLogic.GetAccountRelatedCases(AccountID).HandleResponses(Request);
            }
            else
            {
                var Errors = ModelState.Keys.Where(i => ModelState[i].Errors.Count > 0)
.Select(k => new KeyValuePair<string, string>(k, ModelState[k].Errors.First().ErrorMessage)).ToList();
                return Request.CreateResponse<RetrieveCasesResponse>(new RetrieveCasesResponse
                {
                    ProcessingStatus = ProcessStatusEnum.Error.ToString(),
                    ProcessingCode = "400",
                    ProcessingMessage = Errors.FirstOrDefault().Value.ToString()

                });
            }
        }

    }
}
