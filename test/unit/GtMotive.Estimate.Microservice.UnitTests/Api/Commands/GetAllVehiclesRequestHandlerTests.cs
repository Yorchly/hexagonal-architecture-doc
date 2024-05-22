using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.Queries;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api.Commands
{
    public class GetAllVehiclesRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnPresenter_WhenRequestIsCorrect()
        {
            // Arrange
            var useCaseMock = new Mock<IGetAllVehiclesUseCase>();
            var presenter = new Mock<IGetAllVehiclePresenter>();
            var requestHandler = new GetAllVehiclesRequestHandler(
                useCaseMock.Object, presenter.Object);

            // Act
            var result = await requestHandler.Handle(
                new GetAllVehiclesRequest(),
                cancellationToken: default);

            // Assert
            Assert.NotNull(result);
        }
    }
}
