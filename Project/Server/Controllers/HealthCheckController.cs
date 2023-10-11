using Microsoft.AspNetCore.Mvc;

namespace Project.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {

        public HealthCheckController()
        {
            
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            DateTime timenow = DateTime.Now;
            String getmessage = $"Healthcheck {timenow.Date.ToLongDateString()} ---> Date Time Now {timenow.Hour} : {timenow.Minute}";
            return Ok(getmessage);

        }
    }
}