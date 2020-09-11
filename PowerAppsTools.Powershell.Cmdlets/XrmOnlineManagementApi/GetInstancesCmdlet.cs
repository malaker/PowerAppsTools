using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using System.Collections.Generic;
    using System.Threading;
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Models;

    [Cmdlet(VerbsCommon.Get, "Instances")]
    [OutputType(typeof(IEnumerable<Instance>))]
    public class GetInstancesCmdlet : XrmOnlineManagementApiCmdlet
    {
        protected override void ProcessRecord()
        {
            var result = _client.GetInstances(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);
        }
    }
}
