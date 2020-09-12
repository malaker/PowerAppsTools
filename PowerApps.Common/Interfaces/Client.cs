namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common.Exceptions;

    public abstract class Client
    {
        protected JsonSerializer _jsonSerializer;
        HttpClient _httpCLient;

        protected Client()
        {
        }
        /// <summary>
        /// httpClient has to implement oauth
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="httpCLient"></param>
        public Client(HttpClient httpCLient, JsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
            _httpCLient = httpCLient;
        }

        protected virtual async Task<HttpResponseMessage> ExecuteAsync(PowerAppRequest request, CancellationToken cancellationToken)
        {
            var response = await this._httpCLient.SendAsync(this.GetHttpMessageRequest(request), cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                
                throw new ApiCallFailedException($"{(int)response.StatusCode}-{response.StatusCode.ToString()} - content - {content} - reason {response.ReasonPhrase}",response);
            }

            return response;
        }

        protected virtual HttpRequestMessage GetHttpMessageRequest(PowerAppRequest request)
        {
            var req = new HttpRequestMessage(request.Method, request.RequestUri);
            if (req.Method == HttpMethod.Post)
            {
                var content = this._jsonSerializer.Serialize(request);
                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                req.Content = stringContent;
            }
            if (request.Headers.Any())
            {
                foreach (var header in request.Headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            return req;
        }
    }
}
