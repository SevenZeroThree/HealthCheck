using System;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Mvc
{
    public class HealthCheckController : Controller
    {
        [Route("Health")]
        public IActionResult Get()
        {
            return View();
        }
    }
}
