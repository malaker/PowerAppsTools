using System.Linq;
using Malaker.PowerAppsTools.PowerAppAdvisorClient;
using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;
using Malaker.PowerAppsTools.Powershell.Cmdlets;
using Moq;
using Xunit;
using AutoFixture;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using System;

namespace Tests.Powershell.Cmdlets.PowerAppAdvisor
{
    public class InvokeCheckAnalysisCmdletStub : InvokeCheckAnalysisCmdlet
    {
        public InvokeCheckAnalysisCmdletStub(IPowerAppAdvisorClient client)
        {
            this._client = client;
        }

        protected override void InitializeClient()
        {
        }
    }

    public class InvokeCheckAnalysisCmdletTests
    {

        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();
            var expectedResponse = fixture.Create<CheckAnalysisResponse>();

            var client = new Mock<IPowerAppAdvisorClient>();

            client.Setup(m => m.CheckAnalysis(It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new InvokeCheckAnalysisCmdletStub(client.Object)
            {
                ApiUrl = fixture.Create<string>(),
                ClientId = fixture.Create<string>(),
                TenantId = fixture.Create<string>(),
                CorrelationId = Guid.NewGuid(),
                Credentials = fixture.Build<OAuthCredentials>().Without(m => m.Certificate).Create()
            };
            var results = sut.Invoke().OfType<CheckAnalysisResponse>().ToList();

            results.First().Should().BeEquivalentTo(expectedResponse);
        }
    }
}