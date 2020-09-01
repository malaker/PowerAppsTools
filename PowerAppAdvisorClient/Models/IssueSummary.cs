namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using Newtonsoft.Json;

    public class IssueSummary
    {
        [JsonProperty("criticalIssueCount")]
        public int CriticalIssueCount { get; set; }

        [JsonProperty("highIssueCount")]
        public int HighIssueCount { get; set; }

        [JsonProperty("mediumIssueCount")]
        public int MediumIssueCount { get; set; }

        [JsonProperty("lowIssueCount")]
        public int lowIssueCount { get; set; }
    }
}
