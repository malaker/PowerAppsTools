using Malaker.PowerAppsTools.OnlineManagementApiClient.Interfaces;
using Malaker.PowerAppsTools.Powershell.Cmdlets;
using AutoFixture;
using Moq;
using Xunit;
using FluentAssertions;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Models;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Requests;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace Tests.Powershell.Cmdlets.XrmOnlineManagementApi
{
    public class RestoreCmdletStub : RestoreCmdlet
    {
        public RestoreCmdletStub(IXrmOnlineManagementApiClient client)
        {
            this._client = client;
        }
        protected override void InitializeClient()
        {
        }
    }

    public class RestoreCmdletTests
    {
        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();

            var expectedResponse = fixture.Create<OperationStatus>();

            var client = new Mock<IXrmOnlineManagementApiClient>();

            client.Setup(m => m.RestoreInstance(It.IsAny<RestoreInstanceRequest>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new RestoreCmdletStub(client.Object)
            {
                Credentials = fixture.Build<OAuthCredentials>().Without(m => m.Certificate).Create(),
                ApiUrl = fixture.Create<string>(),
                ClientId = fixture.Create<string>(),
                TenantId = fixture.Create<string>(),
                TargetInstance = fixture.Create<string>()
            };

            var results = sut.Invoke().OfType<OperationStatus>().ToList();

            results.First().Should().BeEquivalentTo(expectedResponse);
        }
    }
}