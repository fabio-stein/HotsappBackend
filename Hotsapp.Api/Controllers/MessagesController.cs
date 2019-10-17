using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotsapp.Data;
using Hotsapp.Data.Model;

namespace Hotsapp.Api.Controllers.MMessages
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private DataContext _dataContext;
        public MessagesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        public IActionResult GetMessage([FromBody] int Id)
        {
            if (Id == 0)
            {
                var last = _dataContext.Message.LastOrDefault();
                if (last != null)
                    Id = last.Id - 1;
            }
            var nextMessage = _dataContext.Message.Where(m => m.Id > Id && !m.IsInternal).OrderBy(m => m.Id).FirstOrDefault();
            return Ok(nextMessage);
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] MsgInfo msg)
        {
            var send = new Message()
            {
                ExternalNumber = "555599436679",
                InternalNumber = "84826193915",
                Content = msg.message,
                IsInternal = true,
                DateTimeUtc = DateTime.UtcNow,
                Processed = false
            };
            _dataContext.Message.Add(send);
            _dataContext.SaveChanges();
            return Ok();
        }

        public class MsgInfo
        {
            public string message { get; set; }
        }
    }
}