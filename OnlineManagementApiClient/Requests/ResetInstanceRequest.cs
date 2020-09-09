using Newtonsoft.Json;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using System.Net.Http;
    using Models;

    public class ResetInstanceRequest : OnlineManagementApiRequest<OperationStatus>
    {
        public ResetInstanceRequest(string targetInstance)
        {
            this.TargetInstance = targetInstance;
        }

        [JsonIgnore]
        public string TargetInstance { get; }

        public string FriendlyName { get; set; }

        public string DomainName { get; set; }

        public string Purpose { get; set; }

        public string SecurityGroupId { get; set; }

        public string TargetRelease { get; set; }

        public int BaseLanguageCode { get; set; }

        public Currency Currency { get; set; }

        public int PreferredCulture { get; set; }

        public string[] ApplicationNames { get; set; }


        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => $"Instances/{TargetInstance}/Reset";
    }
}