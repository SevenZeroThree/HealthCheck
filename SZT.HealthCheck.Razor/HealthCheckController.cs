using System;
using Microsoft.AspNetCore.Mvc;

namespace SZT.HealthCheck.Razor
{
    public class HealthCheckController : Controller
    {
        [Route("Health")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Health")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet]
        [HttpPost]
        public ActionResult<HealthModel> GetJson()
        {
            var response = new HealthModel 
            {
                Status = "ONLINE",
                Date = DateTime.Now
            };
            return response;
        }
    }
}
