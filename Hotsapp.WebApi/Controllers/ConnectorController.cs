using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WaClient.Connector;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConnectorController : ControllerBase
    {
        private IMemoryCache _cache;
        private WaConnector _connector;
        public ConnectorController(IMemoryCache cache, WaConnector connector)
        {
            _cache = cache;
            _connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConnection([FromBody] ConnectionModel data)
        {
            if (data.processId == null)
                data.processId = Guid.NewGuid().ToString();

            bool isNew = false;

            var state = _cache.GetOrCreate<ConnectionState>(data.processId, (o) =>
            {
                o.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                isNew = true;
                return new ConnectionState()
                {
                    processId = data.processId
                };
            });
            var client = _connector.GetClient();
            var status = await client.GetStatus();
            if(isNew)
                await client.Initialize(new WaClient.Connector.Model.InitializeOptions() { });
            data.qrCodeData = status.qr;
            data.finished = false;

            if(status.session != null && status.clientInfo != null)
            {
                using(var conn = DataFactory.GetDataContext())
                {
                    var number = status.clientInfo.me.user + "@" + status.clientInfo.me.server;

                    var phone = conn.WaPhone.FirstOrDefault(p => p.Number == number);
                    var newPhone = phone == null;
                    if (phone == null)
                        phone = new Data.Model.WaPhone()
                        {
                            DefaultMessage = "Test",
                            IsConnected = false,
                            Number = number,
                            OwnerId = User.GetUserId(),
                            Session = status.session.ToJson()
                        };

                    phone.Session = status.session.ToJson();

                    if (newPhone)
                    {
                        conn.WaPhone.Add(phone);
                        conn.WaPhoneArea.Add(new Data.Model.WaPhoneArea()
                        {
                            Id = 1,
                            PhoneNumber = phone.Number,
                            Title = "Geral"
                        });
                    }
                    else
                        conn.WaPhone.Update(phone);
                    await conn.SaveChangesAsync();
                }
                data.finished = true;
                await client.Stop();
            }
            return Ok(data);
        }

        public class ConnectionState
        {
            public string processId { get; set; }
            public string qr { get; set; }
        }

        public class ConnectionModel
        {
            public string processId { get; set; }
            public string qrCodeData { get; set; }
            public bool finished { get; set; }
        }
    }
}
