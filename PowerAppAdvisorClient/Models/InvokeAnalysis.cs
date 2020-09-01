namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class InvokeAnalysis : PowerAppAdivsorMessage
    {
        public InvokeAnalysis(string[] sasUriList, string tenantId, Guid correlationId) : base(tenantId, correlationId)
        {
            this.SasUriList = sasUriList;
        }

        public override HttpMethod Method => HttpMethod.Post;
        
        public override string RequestUri => "api/analyze";

        [JsonProperty("sasUriList")]
        public string[] SasUriList { get; }
    }
}
