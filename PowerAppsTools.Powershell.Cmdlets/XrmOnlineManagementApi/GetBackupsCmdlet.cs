using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient.Requests;
    using System.Threading;
    using Malaker.PowerAppsTools.OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsCommon.Get, "Backups")]
    [OutputType(typeof(GetInstanceBackupsResponse))]
    public class GetBackupsCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("TargetInstance")]
        [ValidateNotNullOrEmpty()]
        public string TargetInstance { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.GetInstanceBackups(new GetInstanceBackups(TargetInstance), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);
        }
    }
}
