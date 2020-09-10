using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Malaker.PowerAppsTools.Common.Interfaces;
using Malaker.PowerAppsTools.OnlineManagementApiClient;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Requests;
using Moq;
using Xunit;
using FluentAssertions;
using System;

namespace Tests.RequestHandlers
{
    public abstract class RequestHandlerTests<TRequestHandler, TRequest, TResponse>
    where TRequest : OnlineManagementApiRequest<TResponse>
    where TRequestHandler : OnlineManagementApiClientRequestHandler<TRequest, TResponse>
    {

        protected Fixture fixture = new Fixture();
        protected Mock<HttpClient> httpClientMock = new Mock<HttpClient>();

        protected Mock<JsonSerializer> jsonSerializer = new Mock<JsonSerializer>();

        public RequestHandlerTests()
        {
            var dummyHttpResponse = new HttpResponseMessage() { Content = new StringContent("", System.Text.Encoding.UTF8, "application/json") };
            httpClientMock.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(dummyHttpResponse));
            jsonSerializer.CallBase = true;
            jsonSerializer.Setup(m => m.Serialize(It.IsAny<object>())).Returns("");
        }

        [Fact]
        public async virtual Task ShouldSendRequestAndReceiveResponse()
        {
            //Arrange
            TResponse expectedResponse = this.fixture.Create<TResponse>();

            jsonSerializer.Setup(m => m.Deserialize(It.IsAny<string>())).Returns(expectedResponse);

            TRequest request = this.fixture.Create<TRequest>();

            var sut = (TRequestHandler)Activator.CreateInstance(typeof(TRequestHandler), new object[] { httpClientMock.Object, jsonSerializer.Object });
            //Act
            var status = await sut.SendAsync(request, CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }
    }
}