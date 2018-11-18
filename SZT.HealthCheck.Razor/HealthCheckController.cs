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
    }
}
