using Microsoft.AspNetCore.Mvc;

namespace ORG.PostsAPI.Controllers
{
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        [Route("IsAlive")]
        public IActionResult IsAlive()
        {
            return Ok();
        }
    }
}
