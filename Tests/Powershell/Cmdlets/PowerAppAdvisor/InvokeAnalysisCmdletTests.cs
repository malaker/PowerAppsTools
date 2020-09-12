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
    public class InvokeAnalysisCmdletStub : InvokeAnalysisCmdlet
    {
        public InvokeAnalysisCmdletStub(IPowerAppAdvisorClient client)
        {
            this._client = client;
        }

        protected override void InitializeClient()
        {
        }
    }

    public class InvokeAnalysisCmdletTests
    {

        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();
            var expectedResponse = fixture.Create<InvokeAnalysisResponse>();

            var client = new Mock<IPowerAppAdvisorClient>();

            client.Setup(m => m.InvokeAnalysis(It.IsAny<UploadMessageResponse>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new InvokeAnalysisCmdletStub(client.Object)
            {
                Credentials = fixture.Build<OAuthCredentials>().Without(m => m.Certificate).Create(),
                ApiUrl = fixture.Create<string>(),
                ClientId = fixture.Create<string>(),
                TenantId = fixture.Create<string>(),
                UploadMessageResponse = fixture.Create<UploadMessageResponse>()
            };
            var results = sut.Invoke().OfType<InvokeAnalysisResponse>().ToList();

            results.First().Should().BeEquivalentTo(expectedResponse);
        }
    }
}