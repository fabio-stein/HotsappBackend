using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : BaseController
    {
        [HttpPost("{numberId}")]
        public async Task<IActionResult> GetUpdate([FromRoute] string numberId, [FromBody] DateTime current)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                var contacts = await conn.QueryAsync<Contact>(@"SELECT m.ExternalNumber AS NumberId, MAX(m.DateTimeUTC) AS ContactDateUTC FROM message m
  INNER JOIN number_period np ON ((m.DateTimeUTC BETWEEN np.StartDateUTC AND np.EndDateUTC) OR (m.DateTimeUTC >= np.StartDateUTC AND np.EndDateUTC IS NULL)) AND np.VirtualNumberId = m.InternalNumber
  WHERE np.UserId = @userId
  AND np.VirtualNumberId = @numberId
  GROUP BY m.ExternalNumber
  ORDER BY ContactDateUTC DESC", new { userId = UserId, numberId});
                return Ok(contacts);
            }
        }
    }

    public class ChatUpdate
    {

    }

    public class Contact
    {
        public string NumberId { get; set; }
        public DateTime ContactDateUTC { get; set; }
    }
}