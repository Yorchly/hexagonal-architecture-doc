using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.MongoDb;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Abstractions
{
    public class FunctionalTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MongoDbContainer _mongoDbContainer = new MongoDbBuilder()
            .WithImage("mongodb/mongodb-community-server:6.0-ubi8")
            .WithUsername("user")
            .WithPassword("secret")
            .WithExposedPort(27017)
            .WithEnvironment("MONGO_INITDB_DATABASE", "VehicleStoreTest")
            .Build();

        public Task InitializeAsync()
        {
            return _mongoDbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _mongoDbContainer.DisposeAsync();
            await _mongoDbContainer.StopAsync();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT", "Development");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            builder.UseConfiguration(configuration);
        }
    }
}
