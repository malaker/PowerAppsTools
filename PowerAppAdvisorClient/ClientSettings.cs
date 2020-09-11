namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System.Security.Cryptography.X509Certificates;


    public class ClientSettings
    {
        public string BaseAddress { get; set; } = "https://europe.api.advisor.powerapps.com";

        public string ClientId { get; set; }

        public string TenantId { get; set; }

        public string Secret { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public string Authority { get; set; }
        
        /// <summary>
        /// Optional in client credential flow Redirect Uri is optional
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.identity.client.applicationoptions.redirecturi?view=azure-dotnet
        /// </summary>
        /// <value></value>
        public string RedirectUri { get; set; }

        public string[] Scopes { get; set; } = new [] { "https://api.advisor.powerapps.com//.default" };
    }
}
