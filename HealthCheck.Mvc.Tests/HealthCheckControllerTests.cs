using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HealthCheck.Mvc.Tests
{
    public class HealthCheckControllerTests
    {
        private HealthCheckController _controller;

        public HealthCheckControllerTests()
        {
            _controller = new HealthCheckController();
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
