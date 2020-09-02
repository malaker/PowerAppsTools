namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common.Exceptions;

    public abstract class Client
    {
        
        HttpClient _httpCLient;

        protected Client()
        {
        }
        /// <summary>
        /// httpClient has to implement oauth
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="httpCLient"></param>
        public Client(HttpClient httpCLient)
        {
            _httpCLient = httpCLient;
        }

        protected virtual async Task<HttpResponseMessage>  ExecuteAsync(PowerAppMessage message, CancellationToken cancellationToken)
        {
            var response = await this._httpCLient.SendAsync(message.GetHttpMessageRequest(), cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response?.Content.ReadAsStringAsync() ?? string.Empty;

                throw new ApiCallFailedException($"{(int)response.StatusCode}-{response.StatusCode.ToString()} - content - {content}");
            }
            
            return response;
        }
    }
}
