using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Abstractions
{
    public class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>
    {
        public BaseFunctionalTest(FunctionalTestWebAppFactory factory)
        {
            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            HttpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:44367"),
                AllowAutoRedirect = false
            });
        }

        public HttpClient HttpClient { get; init; }
    }
}
