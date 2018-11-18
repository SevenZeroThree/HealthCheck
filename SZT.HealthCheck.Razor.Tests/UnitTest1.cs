using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace SZT.HealthCheck.Razor.Tests
{
    public class HealthCheckControllerTests
    {
        private readonly HealthCheckController _controller;

        public HealthCheckControllerTests()
        {
            _controller = new HealthCheckController();
        }

        [Fact]
        public void Get_Has_RouteAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("Get");

            // Act
            var attribute = (RouteAttribute)method.GetCustomAttributes(typeof(RouteAttribute), false).FirstOrDefault();

            // Assert
            Assert.Equal("Health", attribute.Template);
        }

        [Fact]
        public void Get_Returns_View()
        {
            // Arrange

            // Act
            var result = _controller.Get();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }
    }
}
