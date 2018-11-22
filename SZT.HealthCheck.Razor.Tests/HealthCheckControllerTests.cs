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

        #region Index

        [Fact]
        public void Index_Has_RouteAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("Index");

            // Act
            var attribute = (RouteAttribute)method.GetCustomAttributes(typeof(RouteAttribute), false).FirstOrDefault();

            // Assert
            Assert.Equal("Health", attribute.Template);
        }

        [Fact]
        public void Index_Has_HttpGetAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("Index");

            // Act
            var attribute = (HttpGetAttribute)method.GetCustomAttributes(typeof(HttpGetAttribute), false).FirstOrDefault();

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void Index_Returns_View()
        {
            // Arrange

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        #endregion

        #region GetJson

        [Fact]
        public void GetJson_Has_RouteAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("GetJson");

            // Act
            var attribute = (RouteAttribute)method.GetCustomAttributes(typeof(RouteAttribute), false).FirstOrDefault();

            // Assert
            Assert.Equal("Health", attribute.Template);
        }

        [Fact]
        public void GetJson_Has_HttpGetAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("GetJson");

            // Act
            var attribute = (HttpGetAttribute)method.GetCustomAttributes(typeof(HttpGetAttribute), false).FirstOrDefault();

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetJson_Has_HttpPostAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("GetJson");

            // Act
            var attribute = (HttpPostAttribute)method.GetCustomAttributes(typeof(HttpPostAttribute), false).FirstOrDefault();

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetJson_Has_ConsumesAttributee()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("GetJson");

            // Act
            var attribute = (ConsumesAttribute)method.GetCustomAttributes(typeof(ConsumesAttribute), false).FirstOrDefault();

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetJson_Has_ProducesAttribute()
        {
            // Arrage
            var method = _controller.GetType().GetMethod("GetJson");

            // Act
            var attribute = (ProducesAttribute)method.GetCustomAttributes(typeof(ProducesAttribute), false).FirstOrDefault();

            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetJson_Returns_Data()
        {
            // Arrange

            // Act
            var result = _controller.GetJson();

            // Assert
            Assert.NotNull(result);
            var model = result.Value;
            Assert.NotNull(model);
            Assert.Equal("ONLINE", model.Status);
            Assert.Equal(DateTime.Now.ToShortDateString(), model.Date.ToShortDateString());
        }

        #endregion
    }
}
