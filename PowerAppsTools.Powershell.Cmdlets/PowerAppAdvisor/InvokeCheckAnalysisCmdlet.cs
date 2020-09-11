using System;
using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using PowerAppAdvisorClient.Models;

    [Cmdlet(VerbsLifecycle.Invoke, "CheckAnalysis")]
    [OutputType(typeof(CheckAnalysisResponse))]
    public class InvokeCheckAnalysisCmdlet : PowerAppAdvisorApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("UploadMessageResponse")]
        [ValidateNotNull()]
        public Guid? CorrelationId { get; set; }

        protected override void ProcessRecord()
        {
            var result = _client.CheckAnalysis(this.TenantId, this.CorrelationId.Value, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(result);
        }
    }
}
