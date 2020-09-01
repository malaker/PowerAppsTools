namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using Newtonsoft.Json;

    public class InvokeAnalysisResponse
    {
        [JsonProperty("Location")]
        public string[] Location { get; set; }
    }
}
