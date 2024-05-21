using System;
using System.Net.Http;
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

            HttpClient = factory.CreateClient();
        }

        public HttpClient HttpClient { get; init; }
    }
}
