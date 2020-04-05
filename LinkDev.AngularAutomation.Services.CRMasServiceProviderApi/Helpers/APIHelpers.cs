using LinkDev.AngularAutomation.Services.CRMasServiceLogic.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace LinkDev.AngularAutomation.Services.CRMasServiceProviderApi.Helpers
{
    public static class APIHelpers
    {
        public static HttpResponseMessage HandleResponses(this CreateRecordResponse response, HttpRequestMessage request)
        {
            var handledResponseMessage = request.CreateResponse(
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString()
                    ? HttpStatusCode.BadRequest
                    : HttpStatusCode.OK, response);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingStatus", response.ProcessingStatus.ToString());
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingMessage", response.ProcessingMessage);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingCode",
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString() ? "400" : "200");
            return handledResponseMessage;
        }


        public static HttpResponseMessage HandleResponses(this AccountCases response, HttpRequestMessage request)
        {
            var handledResponseMessage = request.CreateResponse(
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString()
                    ? HttpStatusCode.BadRequest
                    : HttpStatusCode.OK, response);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingStatus", response.ProcessingStatus.ToString());
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingMessage", response.ProcessingMessage);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingCode",
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString() ? "400" : "200");
            return handledResponseMessage;
        }

        public static HttpResponseMessage HandleResponses(this RetrieveCasesResponse response, HttpRequestMessage request)
        {
            var handledResponseMessage = request.CreateResponse(
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString()
                    ? HttpStatusCode.BadRequest
                    : HttpStatusCode.OK, response);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingStatus", response.ProcessingStatus.ToString());
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingMessage", response.ProcessingMessage);
            handledResponseMessage.Headers.Add("X-SuadiaCargo-ProcessingCode",
                response.ProcessingStatus == ProcessStatusEnum.Error.ToString() ? "400" : "200");
            return handledResponseMessage;
        }


    }
}