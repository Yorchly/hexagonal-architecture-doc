using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.FunctionalTests.Abstractions;
using Newtonsoft.Json;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Vehicles
{
    public class RentVehicleTests : BaseFunctionalTest
    {
        public RentVehicleTests(FunctionalTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task RentCar_ShouldReturnBadRequest_WhenClientHasAlreadyAVehicleRented()
        {
            // Arrange
            var request =
                new CreateVehicleRequest("Ford", "Mustang", DateTime.Now);
            var response =
                await HttpClient.PostAsJsonAsync("vehicle", request);
            var vehicle =
                JsonConvert.DeserializeObject<VehicleResponse>(
                    await response.Content.ReadAsStringAsync());
            var rentRequest =
                new RentVehicleRequest(vehicle.Id, "Jorge");
            await HttpClient.PutAsJsonAsync($"vehicle/{vehicle.Id}/rent", rentRequest);

            // Act
            var rentResponse =
                await HttpClient.PutAsJsonAsync($"vehicle/{vehicle.Id}/rent", rentRequest);

            // Assert
            rentResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
