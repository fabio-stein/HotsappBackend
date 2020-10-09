using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}
