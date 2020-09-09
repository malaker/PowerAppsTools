using System;
using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{

    using Models;

    public class RestoreInstanceRequest : OnlineManagementApiRequest<OperationStatus>
    {
        public RestoreInstanceRequest(string targetInstanceId)
        {
            this.TargetInstanceId = targetInstanceId;
        }

        public DateTime CreatedOn { get; set; }

        public string TargetInstanceId { get; }

        public string InstanceBackupId { get; set; }

        public string Label { get; set; }
        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => $"Instances/{this.TargetInstanceId}/Restore";
    }
}