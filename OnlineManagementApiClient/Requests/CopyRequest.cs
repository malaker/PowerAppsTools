using System.Net.Http;
using Newtonsoft.Json;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using Models;

    public class CopyRequest : OnlineManagementApiRequest<OperationStatus>
    {
        public CopyRequest(string sourceInstanceId, string targetInstanceId, string friendlyName)
        {
            this.SourceInstanceId = sourceInstanceId;
            this.TargetInstanceId = targetInstanceId;
            this.FriendlyName = friendlyName;
        }

        [JsonIgnore]
        public string SourceInstanceId { get; }

        public string FriendlyName { get; }

        public string SecurityGroupId { get; set; }

        public string TargetInstanceId { get; }

        public string CopyType { get; set; } = "FullCopy";


        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => $"Instances/{SourceInstanceId}/Copy";
    }
}