using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Requests;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsData.Restore, "Instance")]
    [OutputType(typeof(OperationStatus))]
    public class RestoreCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("TargetInstance")]
        [ValidateNotNullOrEmpty()]
        public string TargetInstance { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.RestoreInstance(new RestoreInstanceRequest(TargetInstance), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);

        }
    }
}
