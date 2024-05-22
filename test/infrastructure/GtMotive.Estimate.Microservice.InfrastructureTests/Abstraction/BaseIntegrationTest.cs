using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Abstraction
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
#pragma warning disable CA1051 // Do not declare visible instance fields
#pragma warning disable SA1401 // Fields should be private
        protected readonly ISender Sender;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // Do not declare visible instance fields

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

#pragma warning disable CA2000 // Dispose objects before losing scope
            var scope = factory.Services.CreateScope();
#pragma warning restore CA2000 // Dispose objects before losing scope

            Sender = scope.ServiceProvider.GetService<ISender>();
        }
    }
}
