namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class CheckAnalysisStatus : PowerAppAdivsorRequest
    {
        public CheckAnalysisStatus(string tenantId, Guid correlationId) : base(tenantId, correlationId)
        {
        }

        public override HttpMethod Method => HttpMethod.Get;

        public override string RequestUri => $"api/status/{_correlationId}";
    }
}
