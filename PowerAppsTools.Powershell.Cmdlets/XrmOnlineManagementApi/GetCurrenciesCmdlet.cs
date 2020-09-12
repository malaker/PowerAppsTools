using System.Management.Automation;
using System.Threading;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using System.Collections.Generic;
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Requests;
    using OnlineManagementApiClient.Models;


    [Cmdlet(VerbsCommon.Get, "Currencies")]
    [OutputType(typeof(IEnumerable<CurrencyResponse>))]
    public class GetCurrenciesCmdlet : XrmOnlineManagementApiCmdlet
    {
        protected override void ProcessRecord()
        {
            var result = _client.GetCurrencies(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            WriteObject(result);

        }

    }
}
