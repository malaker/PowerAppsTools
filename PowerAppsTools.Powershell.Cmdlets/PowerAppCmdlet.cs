using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    public abstract class PowerAppCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("ClientId")]
        [ValidateNotNullOrEmpty()]
        public string ClientId { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("TenantId")]
        [ValidateNotNullOrEmpty()]
        public string TenantId { get; set; }

        [Parameter(Mandatory = true)]
        [Alias("Credentials")]
        [ValidateNotNull()]
        public OAuthCredentials Credentials { get; set; }
    }
}
