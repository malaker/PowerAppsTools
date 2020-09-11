using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient.Requests;
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsCommon.New, "Backup")]
    [OutputType(typeof(OperationStatus))]
    public class NewBackupCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("TargetInstance")]
        [ValidateNotNullOrEmpty()]
        public string TargetInstance { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("Label")]
        [ValidateNotNullOrEmpty()]
        public string Label { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.BackupInstance(new BackupInstanceRequest(TargetInstance, Label), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);
        }
    }
}
