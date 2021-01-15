using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using(var conn = DataFactory.GetDataContext())
            {
                return Ok(conn.WaPhone.Where(p => p.OwnerId == User.GetUserId()).ToList().Select(n => new
                {
                    Number = n.Number.Split('@')[0],
                    n.IsConnected
                }));
            }
        }
    }
}
