namespace Tests
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoFixture;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;
    using FluentAssertions;

    public class ClientTests
    {
        private Mock<HttpClient> _httpClientMoq;
        private IPowerAppAdvisorClient _sut;

        public ClientTests()
        {
            this._httpClientMoq = new Mock<HttpClient>();
            this._sut = new AdvisorClient(_httpClientMoq.Object);
        }

        [Fact]
        public async Task ShouldExecuteUploadRequest()
        {
            string[] expectedOutput = new string[] { "1", "2" };

            var expectedResponse = new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(expectedOutput), System.Text.Encoding.UTF8, "application/json") };

            this._httpClientMoq.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var result = await _sut.UploadSolution(new byte[24] , "test", Guid.NewGuid().ToString(), Guid.NewGuid(), default);

            Assert.Equal(expectedOutput, result.SasUriList);
        }


        [Fact]
        public async Task ShouldExecuteInvokeAnalysisRequest()
        {
            string tenantId = Guid.NewGuid().ToString();
            Guid correlationId = Guid.NewGuid();
            string[] sasUrls = new string[] { "1"};

            var expectedResponse = new HttpResponseMessage() { Content = new StringContent("",System.Text.Encoding.UTF8, "application/json") };
            expectedResponse.Headers.Add("Location",sasUrls);
            this._httpClientMoq.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var result = await _sut.InvokeAnalysis(new UploadMessageResponse(sasUrls,tenantId,correlationId), default);

            Assert.Equal(sasUrls, result.Location);
        }


        [Fact]
        public async Task ShouldExecuteCheckAnalysisRequest()
        {
            Fixture fixture = new Fixture();
            string tenantId = Guid.NewGuid().ToString();
            Guid correlationId = Guid.NewGuid();
            CheckAnalysisResponse expected = fixture.Create<CheckAnalysisResponse>();

            var expectedResponse = new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(expected), System.Text.Encoding.UTF8, "application/json") };

            this._httpClientMoq.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));

            var result = await _sut.CheckAnalysis(tenantId, correlationId, default);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
