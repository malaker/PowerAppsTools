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
    public class ResetCmdletStub : ResetCmdlet
    {
        public ResetCmdletStub(IXrmOnlineManagementApiClient client)
        {
            this._client = client;
        }
        protected override void InitializeClient()
        {
        }
    }

    public class ResetCmdletTests
    {
        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();

            var expectedResponse = fixture.Create<OperationStatus>();

            var client = new Mock<IXrmOnlineManagementApiClient>();

            client.Setup(m => m.ResetInstance(It.IsAny<ResetInstanceRequest>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new ResetCmdletStub(client.Object)
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