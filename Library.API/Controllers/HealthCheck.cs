using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheck : ControllerBase
    {
        [HttpGet("TestHelth")]
        public string Get()
        {
            return $"Api está ativa!";
        }
    }
}
