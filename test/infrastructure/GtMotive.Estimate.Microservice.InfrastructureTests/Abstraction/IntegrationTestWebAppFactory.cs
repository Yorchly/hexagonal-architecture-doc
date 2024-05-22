using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.MongoDb;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Abstraction
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        // Test will thrown an exception if I dispose mongoDbContainer.
#pragma warning disable CA2213 // Disposable fields should be disposed
        private readonly MongoDbContainer _mongoDbContainer = new MongoDbBuilder()
#pragma warning restore CA2213 // Disposable fields should be disposed
            .WithImage("mongodb/mongodb-community-server:6.0-ubi8")
            .WithPortBinding(27017)
            .Build();

        public async Task InitializeAsync()
        {
            await _mongoDbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _mongoDbContainer.StopAsync();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT", "Development");
            Environment.SetEnvironmentVariable(
                "MONGODB_CONNECTION_STRING", _mongoDbContainer.GetConnectionString());
            Environment.SetEnvironmentVariable(
                "MONGODB_DATABASE_NAME", "VehicleStoreTest");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            builder.UseConfiguration(configuration);

            builder.UseUrls("http://localhost:44367");
        }
    }
}
