using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient.Requests;
    using System.Threading;
    using Malaker.PowerAppsTools.OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsLifecycle.Invoke, "CopyRequest")]
    [OutputType(typeof(OperationStatus))]
    public class IvokeCopyRequestCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("TargetInstance")]
        [ValidateNotNullOrEmpty()]
        public string TargetInstance { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("SourceInstance")]
        [ValidateNotNullOrEmpty()]
        public string SourceInstance { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("FriendlyName")]
        [ValidateNotNullOrEmpty()]
        public string FriendlyName { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.CopyEnvironment(new CopyRequest(SourceInstance, TargetInstance, FriendlyName), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);
        }
    }
}
