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
    public class SendManagedSolutionCmdletStub : SendManagedSolutionCmdlet
    {
        public SendManagedSolutionCmdletStub(IPowerAppAdvisorClient client)
        {
            this._client = client;
        }

        protected override void InitializeClient()
        {
        }

        protected override byte[] LoadSolution(string path)
        {
            return new byte[1];
        }
    }

    public class SendManagedSolutionCmdletTests
    {

        [Fact]
        public void ShouldCmdletBeInvoked()
        {
            var fixture = new Fixture();
            var expectedResponse = fixture.Create<UploadMessageResponse>();

            var client = new Mock<IPowerAppAdvisorClient>();

            client.Setup(m => m.UploadSolution(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var sut = new SendManagedSolutionCmdletStub(client.Object)
            {
                ApiUrl = fixture.Create<string>(),
                ClientId = fixture.Create<string>(),
                TenantId = fixture.Create<string>(),
                FullPath = fixture.Create<string>(),
                SolutionName = fixture.Create<string>(),
                Credentials = fixture.Build<OAuthCredentials>().Without(m => m.Certificate).Create()
            };
            var results = sut.Invoke().OfType<UploadMessageResponse>().ToList();

            results.First().Should().BeEquivalentTo(expectedResponse);
        }
    }
}