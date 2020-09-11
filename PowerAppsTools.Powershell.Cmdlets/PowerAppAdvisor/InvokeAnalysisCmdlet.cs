using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using PowerAppAdvisorClient.Models;

    [Cmdlet(VerbsLifecycle.Invoke, "Analysis")]
    [OutputType(typeof(InvokeAnalysisResponse))]
    public class InvokeAnalysisCmdlet : PowerAppAdvisorApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("UploadMessageResponse")]
        [ValidateNotNull()]
        public UploadMessageResponse UploadMessageResponse { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.InvokeAnalysis(UploadMessageResponse, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(result);
        }
    }
}
