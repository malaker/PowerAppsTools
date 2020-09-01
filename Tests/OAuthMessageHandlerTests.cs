namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Microsoft.Identity.Client;
    using Moq;
    using Xunit;

    public class OAuthMessageHandlerTests
    {
        DelegatingHandler sut = null;

        [Fact]
        public async Task ShouldAquireToken()
        {
            var scopes = new List<string>() { "scope1" };

            var confidentialClientMoq = new Mock<IConfidentialClientApplicationWrapper>();

            var tokenBuilder = new Mock<ITokenBuilder>();

            var authResult = new AuthenticationResult(string.Empty, false, string.Empty, DateTimeOffset.UtcNow,DateTimeOffset.UtcNow.AddSeconds(60),string.Empty,null,string.Empty,scopes,Guid.NewGuid(),new AuthenticationResultMetadata(TokenSource.Cache));

            tokenBuilder.Setup(m => m.ExecuteAsync()).Returns(Task.FromResult(authResult)) ;

            confidentialClientMoq.Setup(m => m.AcquireTokenForClient(It.Is<IEnumerable<string>>(r => r == scopes))).Returns(tokenBuilder.Object);

            sut = new OAuthMessageHandler(confidentialClientMoq.Object, scopes);
            sut.InnerHandler = new Mock<HttpMessageHandler>(MockBehavior.Loose).Object;
            var invoker = new HttpMessageInvoker(sut);
            var result = await invoker.SendAsync(new HttpRequestMessage(),default);
        }
    }
}
