using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.InfrastructureTests.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Vehicles
{
    public class CreateVehicleTests : BaseIntegrationTest
    {
        public CreateVehicleTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Create_ShouldAddNewVehicleToDatabase_WhenRequestIsCorrect()
        {
            // Arrange
            var request =
                new CreateVehicleRequest("Ford", "Mustang", DateTime.Now);

            // Act
            var presenter = await Sender.Send(request);

            // Assert
            Assert.NotNull(presenter);
            Assert.Equal(typeof(CreatedAtRouteResult), presenter.ActionResult.GetType());
        }
    }
}
