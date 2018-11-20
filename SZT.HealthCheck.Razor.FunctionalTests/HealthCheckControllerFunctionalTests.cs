using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SZT.HealthCheck.Razor.FunctionalTests
{
    public class HealthCheckControllerFunctionalTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public HealthCheckControllerFunctionalTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Health_Returns_200()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/health");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            var content = await response.Content.ReadAsStringAsync();
            var containsOnlineText = content.Contains("ONLINE");
            Assert.True(containsOnlineText);
        }

        [Fact]
        public async Task Post_Health_Returns_200_Json()
        {
            // Arrange
            var client = _factory.CreateClient();
            var content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                                    Encoding.UTF8,
                                    "application/json");//CONTENT-TYPE header

            // Act
            var response = await client.PostAsync("/health", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();
            var containsOnlineText = responseContent.Contains("ONLINE");
            Assert.True(containsOnlineText);
        }

        [Fact]
        public async Task Get_BadPage_Returns_404()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/not-found");

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
