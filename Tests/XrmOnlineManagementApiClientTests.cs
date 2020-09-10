using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Malaker.PowerAppsTools.Common.Interfaces;
using Malaker.PowerAppsTools.OnlineManagementApiClient;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Models;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Requests;
using Moq;
using Xunit;
using FluentAssertions;

namespace Tests
{
    public class XrmOnlineManagementApiClientTests
    {
        private Fixture fixture;

        public XrmOnlineManagementApiClientTests()
        {
            this.fixture = new AutoFixture.Fixture();
        }

        [Fact]
        public async Task ShouldCallBackupInstanceHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<BackupInstanceRequest, OperationStatus>>();
            var expectedStatus = fixture.Create<OperationStatus>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<BackupInstanceRequest>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedStatus));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            var instanceId = Guid.NewGuid().ToString();
            //Act
            var status = await sut.BackupInstance(new BackupInstanceRequest(instanceId,"testLabel"),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedStatus);
        }

        [Fact]
        public async Task ShouldCallCopyEnvironmentRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<CopyRequest, OperationStatus>>();
            var expectedStatus = fixture.Create<OperationStatus>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<CopyRequest>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedStatus));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            var sourceInstanceId = Guid.NewGuid().ToString();
            var targetInstanceId = Guid.NewGuid().ToString();
            //Act
            var status = await sut.CopyEnvironment(new CopyRequest(sourceInstanceId,targetInstanceId,"name"),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedStatus);
        }


        [Fact]
        public async Task ShouldCallGetCurrenciesRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<GetCurrencies,  List<CurrencyResponse>>>();
            var expectedResponse = fixture.Create<List<CurrencyResponse>>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<GetCurrencies>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            //Act
            var currencyResponse = await sut.GetCurrencies(CancellationToken.None);
            //Assert
            currencyResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldCallGetInstanceBackupsRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<GetInstanceBackups, GetInstanceBackupsResponse>>();
            var expectedResponse = fixture.Create<GetInstanceBackupsResponse>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<GetInstanceBackups>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            var targetInstanceId = Guid.NewGuid().ToString();
            //Act
            var status = await sut.GetInstanceBackups(new GetInstanceBackups(targetInstanceId),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldCallGetInstancesRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<GetInstances, List<Instance>>>();
            var expectedResponse = fixture.Create<List<Instance>>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<GetInstances>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            //Act
            var status = await sut.GetInstances(CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldCallGetOperationStatusRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<GetOperationStatus, OperationStatus>>();
            var expectedResponse = fixture.Create<OperationStatus>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<GetOperationStatus>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            //Act
            var status = await sut.GetOperationStatus(Guid.NewGuid().ToString(),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldCallResetRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<ResetInstanceRequest, OperationStatus>>();
            var expectedResponse = fixture.Create<OperationStatus>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<ResetInstanceRequest>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            //Act
            var status = await sut.ResetInstance(new ResetInstanceRequest(Guid.NewGuid().ToString()),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task ShouldCallRestoreRequestHandler()
        {
            //Arrange
            var handlerMock = new Mock<IRequestHandler<RestoreInstanceRequest, OperationStatus>>();
            var expectedResponse = fixture.Create<OperationStatus>();
            handlerMock.Setup(m=>m.SendAsync(It.IsAny<RestoreInstanceRequest>(),It.IsAny<CancellationToken>())).Returns(Task.FromResult(expectedResponse));
            var sut = new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>(){handlerMock.Object});
            //Act
            var status = await sut.RestoreInstance(new RestoreInstanceRequest(Guid.NewGuid().ToString()),CancellationToken.None);
            //Assert
            status.Should().BeEquivalentTo(expectedResponse);
        }
    }
}