using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Models
{
    public class CurrencyResponse
    {
        public string RegionCode { get; set; }

        public string Name { get; set; }

        public List<Currency> Currencies { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }

        public int Precision { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }
    }
}