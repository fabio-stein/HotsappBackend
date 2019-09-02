using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Api.Controllers.MMessages
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetMessage([FromBody] int Id)
        {
            using(var context = new DataContext())
            {
                if(Id == 0)
                {
                    var last = context.MessageReceived.LastOrDefault();
                    if (last != null)
                        Id = last.Id - 1;
                }
                var nextMessage = context.MessageReceived.Where(m => m.Id > Id).OrderBy(m => m.Id).FirstOrDefault();
                return Ok(nextMessage);
            }
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] MsgInfo msg)
        {
            using(var context = new DataContext())
            {
                var send = new Message()
                {
                    PhoneNumber = "555599436679",
                    UserId = 3,
                    Text = msg.message
                };
                context.Message.Add(send);
                context.SaveChanges();
                return Ok();
            }
        }

        public class MsgInfo
        {
            public string message { get; set; }
        }
    }
}