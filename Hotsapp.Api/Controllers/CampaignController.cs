using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaignController : BaseController
    {
        public class CampaignModel { 
            public string title { get; set; }
            public string contactList { get; set; }
            public string message { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CampaignModel data)
        {
            if (String.IsNullOrWhiteSpace(data.title) || string.IsNullOrWhiteSpace(data.message) || string.IsNullOrWhiteSpace(data.contactList))
                return BadRequest("Campanha inválida");

            List<string> contacts = new List<string>();
            var pattern = @"[^\d]";
            data.contactList.Split("\n").ToList().ForEach(c =>
            {
                var number = Regex.Replace(c, pattern, "");
                if (number.Length == 11 || number.Length == 10)
                    contacts.Add(number);
            });
            if (contacts.Count == 0)
                return BadRequest("Lista de contatos inválida");

            using(var ctx = DataFactory.GetContext())
            {
                var campaign = new Campaign()
                {
                    Id = Guid.NewGuid(),
                    OwnerId = (int)UserId,
                    Title = data.title,
                    MessageToSend = data.message,
                    IsPaused = true
                };
                await ctx.Campaign.AddAsync(campaign);

                var campaignContacts = contacts.Select(c => new CampaignContact()
                {
                    CampaignId = campaign.Id,
                    PhoneNumber = c
                });

                await ctx.CampaignContact.AddRangeAsync(campaignContacts);

                await ctx.SaveChangesAsync();

                return Ok(campaign.Id);
            }
        }

        [HttpPut("{campaignId}")]
        public async Task<IActionResult> Start(Guid campaignId)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var campaign = await ctx.Campaign.SingleOrDefaultAsync(c => c.Id == campaignId && c.OwnerId == (int)UserId);
                if (campaign.IsComplete)
                    return BadRequest("Campanha finalizada");
                campaign.IsPaused = false;
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPut("{campaignId}")]
        public async Task<IActionResult> Stop(Guid campaignId)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var campaign = await ctx.Campaign.SingleOrDefaultAsync(c => c.Id == campaignId && c.OwnerId == (int)UserId);
                if (campaign.IsComplete)
                    return BadRequest("Campanha finalizada");
                campaign.IsPaused = true;
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPut("{campaignId}")]
        public async Task<IActionResult> Cancel(Guid campaignId)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var campaign = await ctx.Campaign.SingleOrDefaultAsync(c => c.Id == campaignId && c.OwnerId == (int)UserId);
                if (campaign.IsComplete)
                    return BadRequest("Campanha finalizada");
                campaign.IsCanceled = true;
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpGet("{status}")]
        public async Task<IActionResult> All(string status)
        {
            using (var ctx = DataFactory.GetContext())
            {
                bool activeOnly = status == "active";
                var list = ctx.Campaign.Where(c => c.OwnerId == (int)UserId && ((!activeOnly) || (activeOnly && !c.IsCanceled && !c.IsComplete))).OrderByDescending(c => c.CreateDateUtc).ToList();
                return Ok(list);
            }
        }

        [HttpGet("{campaignId}")]
        public async Task<IActionResult> Status(string campaignId)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                var info = await conn.QueryFirstOrDefaultAsync<StatusModel>(@"WITH infos AS(
SELECT COUNT(*) AS total, SUM(IF(Processed, 1, 0)) AS processed, SUM(IF(IsSuccess, 1, 0)) AS success
  FROM campaign_contact
  WHERE CampaignId = @campaignId
)
SELECT c.Title AS title,
  IF(c.IsComplete, 'finished', IF(c.IsCanceled, 'canceled', IF(c.IsPaused, 'paused', 'running'))) AS status,
  i.total,
  i.success AS sent,
  (i.processed - i.success) AS failed,
  (i.total - i.processed) AS remaining,
  ROUND((i.processed / i.total) * 100) as percentageComplete
  FROM infos i
  INNER JOIN campaign c ON c.Id = @campaignId
  WHERE c.OwnerId = @ownerId", new
                {
                    ownerId = (int)UserId,
                    campaignId
                });
                return Ok(info);
            }
        }

        public class StatusModel
        {
            public string title { get; set; }
            public string status { get; set; }
            public int total { get; set; }
            public int sent { get; set; }
            public int failed { get; set; }
            public int remaining { get; set; }
            public int percentageComplete { get; set; }
        }
    }
}