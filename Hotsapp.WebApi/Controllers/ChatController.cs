using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var userId = User.GetUserId();
            using (var conn = DataFactory.OpenConnection())
            {
                var res = await conn.QueryAsync(@"SELECT c.*, a.Title AS AreaTitle FROM wa_phone p
INNER JOIN wa_chat c ON c.PhoneNumber = p.Number
INNER JOIN wa_phone_area a ON a.PhoneNumber = p.Number AND a.Id = c.Area
WHERE p.OwnerId = @userId
AND c.IsActive", new { userId });
                return Ok(res);
            }
        }

        public async Task<IActionResult> ChatUpdate([FromBody] ChatUpdateModel data)
        {
            var userId = User.GetUserId();
            using (var conn = DataFactory.OpenConnection())
            {
                var res = await conn.QueryAsync(@"SELECT m.* FROM wa_phone p
INNER JOIN wa_chat c ON c.PhoneNumber = p.Number
INNER JOIN wa_chat_message m ON m.ChatId = c.Id
WHERE p.OwnerId = @userId
AND c.Id = @ChatId
AND m.MessageId > @LastMessageId
ORDER BY m.MessageId ASC", new { userId, data.ChatId, data.LastMessageId });

                return Ok(new { messages = res });
            }
        }

        public async Task<IActionResult> SendMessage([FromBody] SendMessageModel data)
        {
            var userId = User.GetUserId();
            using (var conn = DataFactory.OpenConnection())
            {
                var chat = await conn.QueryFirstOrDefaultAsync<WaChat>(@"SELECT c.* FROM wa_chat c
INNER JOIN wa_phone p ON p.Number = c.PhoneNumber
WHERE p.OwnerId = @userId
AND c.Id = @ChatId
AND c.IsActive", new { userId, data.ChatId });

                if (chat == null)
                    return BadRequest("Invalid chat");

                var res = await conn.QueryAsync(@"
INSERT INTO wa_chat_message (ChatId, ChatPhoneNumber, Body, IsFromMe, IsProcessed) VALUES (@chatId, @phoneNumber, @body, TRUE, FALSE);
", new { chatId = data.ChatId, phoneNumber = chat.PhoneNumber, data.Body });
                return Ok();
            }
        }

        [HttpPost("{chatId}")]
        public async Task<IActionResult> CloseChat(int chatId)
        {
            var userId = User.GetUserId();
            using (var conn = DataFactory.OpenConnection())
            {
                var chat = await conn.QueryFirstOrDefaultAsync<WaChat>(@"SELECT c.* FROM wa_chat c
INNER JOIN wa_phone p ON p.Number = c.PhoneNumber
WHERE p.OwnerId = @userId
AND c.IsActive", new { userId, chatId });

                if (chat == null)
                    return BadRequest("Invalid chat");

                var res = await conn.QueryAsync(@"
UPDATE wa_chat SET IsActive = FALSE WHERE Id = @chatId
", new { chatId });
                return Ok();
            }
        }



        public class ChatUpdateModel
        {
            public int ChatId { get; set; }
            public int LastMessageId { get; set; }
        }

        public class SendMessageModel
        {
            public int ChatId { get; set; }
            public string Body { get; set; }
        }
    }
}
