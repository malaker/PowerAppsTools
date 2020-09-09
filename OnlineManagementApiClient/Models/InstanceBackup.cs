using System;
using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Models
{
    public class AzureStorage
    {
        public string ContainerName { get; set; }

        public string StorageAccountKey { get; set; }

        public string StorageAccountName { get; set; }
    }

    public class ManualBackup
    {
        public string Notes { get; set; }

        public string Label { get; set; }

        public string CreatedByUserPrincipalName { get; set; }

        public string InstanceId { get; set; }

        public string Id { get; set; }

        public DateTime TimestampUtc { get; set; }
        public DateTime ExpiryTimeUtc { get; set; }

    }

    public class SystemBackup
    {
        public string InstanceId { get; set; }

        public DateTime BackupStartTimeUtc { get; set; }

        public DateTime BackupEndTimeUtc { get; set; }
    }

    public class GetInstanceBackupsResponse
    {
        public List<ManualBackup> ManualBackups { get; set; }

        public List<SystemBackup> SystemBackups { get; set; }
    }
}