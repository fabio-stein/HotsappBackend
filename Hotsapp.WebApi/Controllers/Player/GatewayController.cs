using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/gateway")]
    [ApiController]
    [AllowAnonymous]
    public class GatewayController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index([FromQuery] Guid channelId)
        {
            //TODO REPLACE COOKIE BY CUSTOM STREAMER ID
            Response.Cookies.Append("routeKey", channelId.ToString());
            return Ok(new { url = "https://api.hotsapp.net/streamer/streamhub?channelId="+channelId.ToString() });
        }
    }
}