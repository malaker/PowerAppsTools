using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using OnlineManagementApiClient;
    using OnlineManagementApiClient.Interfaces;

    public abstract class XrmOnlineManagementApiCmdlet : PowerAppCmdlet
    {
        protected IXrmOnlineManagementApiClient _client;

        [Parameter(Mandatory = true)]
        [Alias("ApiUrl")]
        [ValidateNotNullOrEmpty()]
        public string ApiUrl { get; set; }

        protected override void BeginProcessing()
        {
            _client = DefaultOnlineManagementApiClientFactory.Instance.Create(new XrmClientSettings()
            {
                ClientId = this.ClientId,
                Certificate = this.Credentials.Certificate,
                Secret = this.Credentials.Secret,
                TenantId = this.TenantId,
                BaseAddress = this.ApiUrl
            });

            base.BeginProcessing();
        }
    }
}
