using System;
using Microsoft.AspNetCore.Mvc;

namespace SZT.HealthCheck.Razor
{
    public class HealthCheckController : Controller
    {
        [Route("Health")]
        public IActionResult Get()
        {
            return View();
        }

        [Route("Health")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult GetJson()
        {
            var response = new {
                Status = "ONLINE",
                Date = DateTime.Now
            };
            return Ok(response);
        }
    }
}
