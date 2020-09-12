using AutoFixture;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Interfaces;
using Malaker.PowerAppsTools.Powershell.Cmdlets;
using Moq;
using Xunit;
using FluentAssertions;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Models;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Requests;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Tests.Powershell.Cmdlets.XrmOnlineManagementApi
{
    public class GetInstancesCmdletStub : GetInstancesCmdlet
    {
        public GetInstancesCmdletStub(IXrmOnlineManagementApiClient client)
        {
            this._client = client;
        }
        protected override void InitializeClient()
        {
        }
    }

    public class GetInstancesCmdletTests
    {
        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();

            var expectedResponse = fixture.Create<IEnumerable<Instance>>();

            var client = new Mock<IXrmOnlineManagementApiClient>();

            client.Setup(m => m.GetInstances(It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new GetInstancesCmdletStub(client.Object)
            {
                Credentials = fixture.Build<OAuthCredentials>().Without(m => m.Certificate).Create(),
                ApiUrl = fixture.Create<string>(),
                ClientId = fixture.Create<string>(),
                TenantId = fixture.Create<string>()
            };

            var results = sut.Invoke().OfType<IEnumerable<Instance>>().ToList();

            results.First().Should().BeEquivalentTo(expectedResponse);
        }
    }
}