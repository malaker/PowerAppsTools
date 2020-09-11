using System;
using System.Management.Automation;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    using System.Security.Cryptography.X509Certificates;

    [Cmdlet(VerbsCommon.New, "Credentials")]
    [OutputType(typeof(OAuthCredentials))]
    public class NewCredentialsCmdlet : Cmdlet
    {
        [Parameter(Mandatory = false)]
        [Alias("Secret")]
        public string Secret { get; set; }

        [Parameter(Mandatory = false)]
        [Alias("Certificate")]
        public X509Certificate2 Certificate { get; set; }

        protected override void ProcessRecord()
        {
            if (string.IsNullOrEmpty(Secret) && Certificate == null)
            {
                throw new ArgumentNullException("Secret and Certificate cannot be both null or empty");
            }

            OAuthCredentials credentials = new OAuthCredentials() { Secret = Secret, Certificate = Certificate };

            WriteObject(credentials);
        }
    }
}
