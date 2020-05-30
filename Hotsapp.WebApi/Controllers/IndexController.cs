using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { running = true });
        }
    }
}