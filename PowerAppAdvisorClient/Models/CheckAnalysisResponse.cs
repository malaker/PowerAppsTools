namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using Newtonsoft.Json;

    public class CheckAnalysisResponse
    {
        [JsonProperty("privacyPolicy")]
        public string PrivacyPolicy { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("runCorrelationId")]
        public Guid RunCorrelationId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("resultFileUris")]
        public string[] ResultFileUris { get; set; }

        [JsonProperty("issueSummary")]
        public IssueSummary IssueSummary { get; set; }
    }
}
