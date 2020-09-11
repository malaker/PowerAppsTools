using System;
using System.IO;
using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using PowerAppAdvisorClient;
    using PowerAppAdvisorClient.Models;


    [Cmdlet(VerbsCommunications.Send, "ManagedSolution")]
    [OutputType(typeof(UploadMessageResponse))]
    public class SendManagedSolutionCmdlet : PowerAppAdvisorApiCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("FullPath")]
        [ValidateNotNullOrEmpty()]
        public string FullPath { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("FullPath")]
        [ValidateNotNullOrEmpty()]
        public string SolutionName { get; set; }


        protected override void ProcessRecord()
        {
            byte[] managedSolution = null;

            using (var fs = File.Open(FullPath, FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Position = 0L;
                    managedSolution = ms.ToArray();
                }
            }

            var result = _client.UploadSolution(managedSolution, SolutionName, TenantId, Guid.NewGuid(), CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(result);

        }
    }
}
