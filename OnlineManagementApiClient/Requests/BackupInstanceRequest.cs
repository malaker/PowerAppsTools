using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using Models;

    public class BackupInstanceRequest : OnlineManagementApiRequest<OperationStatus>
    {
        public BackupInstanceRequest(string instanceId, string label)
        {
            this.InstanceId = instanceId;
            this.Label = label;
        }
        public AzureStorage AzureStorageInformation { get; set; }
        public string InstanceId { get; }

        public bool? IsAzureBackup { get; set; }

        public string Label { get; }

        public string Notes { get; set; }

        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => $"Instances/{this.InstanceId}/Backups";
    }
}