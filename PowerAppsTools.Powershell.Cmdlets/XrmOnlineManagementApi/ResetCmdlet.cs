using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient.Requests;
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsCommon.Reset, "Instance")]
    [OutputType(typeof(OperationStatus))]
    public class ResetCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("TargetInstance")]
        [ValidateNotNullOrEmpty()]
        public string TargetInstance { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.ResetInstance(new ResetInstanceRequest(TargetInstance), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);

        }
    }
}
