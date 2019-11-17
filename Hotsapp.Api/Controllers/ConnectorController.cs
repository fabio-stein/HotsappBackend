using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/connector/[Action]")]
    [ApiController]
    public class ConnectorController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> StartFlow([FromBody] FlowInfo flowInfo)
        {
            var fullNumber = flowInfo.countryCode + flowInfo.areaCode + flowInfo.phoneNumber;
            var cleanNumber = fullNumber.Trim().Replace("+", "").Replace("-", "").Replace(".", "");
            try
            {
                long.Parse(cleanNumber);
            }catch(Exception e)
            {
                return BadRequest();
            }

            using (var ctx = DataFactory.GetContext())
            {
                var flow = new Data.Model.ConnectionFlow()
                {
                    Id = Guid.NewGuid(),
                    CreateDateUtc = DateTime.UtcNow,
                    UserId = (int)UserId,
                    PhoneNumber = cleanNumber,
                    CountryCode = int.Parse(flowInfo.countryCode)
                };
                ctx.ConnectionFlow.Add(flow);
                await ctx.SaveChangesAsync();
                return Ok(flow.Id);
            }
        }

        public class FlowInfo
        {
            public string countryCode { get; set; }
            public string areaCode { get; set; }
            public string phoneNumber { get; set; }
        }

        [HttpPut("{flowId}/{confirmCode}")]
        public async Task<IActionResult> ConfirmCode(Guid flowId, string confirmCode)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var flow = ctx.ConnectionFlow.Where(f => f.Id == flowId && f.UserId == (int)UserId).SingleOrDefault();
                if (flow == null)
                    return BadRequest();
                try
                {
                    int.Parse(confirmCode);
                }catch(Exception e)
                {
                    return BadRequest();
                }
                flow.ConfirmCode = confirmCode;
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpGet("{flowId}")]
        public async Task<IActionResult> CheckFlowStatus(Guid flowId)
        {
            using(var ctx = DataFactory.GetContext())
            {
                var flow = ctx.ConnectionFlow.Where(f => f.Id == flowId && f.UserId == (int)UserId).SingleOrDefault();
                if (flow == null)
                    return BadRequest();
                return Ok(flow);
            }
        }
    }
}