namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Newtonsoft.Json;

    public abstract class Message
    {
        [JsonIgnore()]
        public abstract HttpMethod Method { get; }
        [JsonIgnore()]
        public abstract string RequestUri { get; }
        [JsonIgnore()]
        public Dictionary<string, string> Headers = new Dictionary<string, string>();
        public abstract HttpRequestMessage GetHttpMessageRequest();
    }
}
