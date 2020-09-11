using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using Malaker.PowerAppsTools.OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsCommon.Get, "OperationStatus")]
    [OutputType(typeof(OperationStatus))]
    public class GetOperationStatusCmdlet : XrmOnlineManagementApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("OperationId")]
        [ValidateNotNullOrEmpty()]
        public string OperationId { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.GetOperationStatus(OperationId, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);
        }

    }
}
