using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hotsapp.Data.Model;
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
        public async Task<IActionResult> ContactUpdate([FromRoute] string numberId, [FromBody] DateTime current)
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

        [HttpPost]
        public async Task<IActionResult> ChatUpdate([FromBody] ChatUpdateRequest data)
        {
            using (var conn = DataFactory.OpenConnection())
            {
                var lastUpdateCondition = "";
                var includeInternal = true;
                if (data.LastUpdate != null)
                {
                    lastUpdateCondition = " AND m.DateTimeUTC > @lastUpdate ";
                    includeInternal = false;
                }
                var messages = await conn.QueryAsync<ChatMessage>($@"SELECT m.Content, m.DateTimeUTC, m.IsInternal FROM message m
  WHERE m.InternalNumber = @internalNumber
  AND m.ExternalNumber = @externalNumber
  AND m.UserId = @userId
  AND (@includeInternal OR !m.IsInternal)
  {lastUpdateCondition}
  ORDER BY m.DateTimeUTC ASC", new
                {
                    lastUpdate = data.LastUpdate,
                    externalNumber = data.ContactNumber,
                    internalNumber = data.NumberId,
                    userId = UserId,
                    includeInternal
                });

                var lastMessage = messages.LastOrDefault()?.DateTimeUTC;
                if (lastMessage == null && data.LastUpdate != null)
                    lastMessage = data.LastUpdate;

                var update = new ChatUpdate()
                {
                    LastUpdate = lastMessage,
                    Messages = messages
                };
                return Ok(update);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest data)
        {
            using(var context = DataFactory.GetContext())
            {
                var message = new Message()
                {
                    UserId = (int)UserId,
                    Content = data.Content,
                    InternalNumber = data.NumberId,
                    ExternalNumber = data.ContactNumber,
                    IsInternal = true,
                    DateTimeUtc = DateTime.UtcNow,
                    Processed = false
                };
                await context.Message.AddAsync(message);
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }

    public class SendMessageRequest
    {
        public string NumberId { get; set; }
        public string ContactNumber { get; set; }
        public string Content { get; set; }
    }

    public class ChatUpdateRequest
    {
        public string NumberId { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? LastUpdate { get; set; }
    }

    public class ChatUpdate
    {
        public DateTime? LastUpdate { get; set; }
        public IEnumerable<ChatMessage> Messages { get; set; }
    }

    public class ChatMessage
    {
        public string Content { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public bool IsInternal { get; set; }
    }

    public class Contact
    {
        public string NumberId { get; set; }
        public DateTime ContactDateUTC { get; set; }
    }
}