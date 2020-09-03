namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Models
{
    public class Instance
    {
        public string Id { get; set; }

        public string UniqueName { get; set; }

        public string Version { get; set; }

        public string ApplicationUrl { get; set; }
        public bool StateIsSupportedForDelete { get; set; }

        public bool AdminMode { get; set; }

        public bool IsLocked { get; set; }

        public string ApiUrl { get; set; }

        public string FriendlyName { get; set; }

        public string DomainName { get; set; }

        public string InitialUserPrincipalName { get; set; }

        public int BaseLanguage { get; set; }

        public string InitialUserEmail { get; set; }

        public string SecurityGroupId { get; set; }
    }
}