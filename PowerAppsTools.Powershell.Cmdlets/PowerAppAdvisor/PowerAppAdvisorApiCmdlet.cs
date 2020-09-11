using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using PowerAppAdvisorClient;
    public abstract class PowerAppAdvisorApiCmdlet : PowerAppCmdlet
    {
        protected IPowerAppAdvisorClient _client;

        [Parameter(Mandatory = true)]
        [Alias("ApiUrl")]
        [ValidateNotNullOrEmpty()]
        public string ApiUrl { get; set; }

        protected override void BeginProcessing()
        {
            InitializeClient();
            base.BeginProcessing();
        }

        protected virtual void InitializeClient()
        {
            _client = DefaultClientFactory.Instance.Create(new ClientSettings()
            {
                ClientId = this.ClientId,
                Certificate = this.Credentials.Certificate,
                Secret = this.Credentials.Secret,
                TenantId = this.TenantId,
                BaseAddress = this.ApiUrl
            });
        }
    }
}
