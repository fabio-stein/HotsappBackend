using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/gateway")]
    [ApiController]
    [AllowAnonymous]
    public class GatewayController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index([FromQuery] Guid channelId, [FromServices] IConfiguration config)
        {
            //TODO REPLACE COOKIE BY CUSTOM STREAMER ID
            Response.Cookies.Append("routeKey", channelId.ToString());

            string url = config["ApiAddress"] + "/streamhub?channelId=" + channelId.ToString();

            return Ok(new { url });
        }
    }
}