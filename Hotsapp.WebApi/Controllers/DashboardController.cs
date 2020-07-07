using Dapper;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] YouTubeCacheService youTubeCacheService)
        {
            var sql = @"WITH mediaDates AS(
SELECT p.ChannelId, MAX(p.StartDateUTC) AS lastDate FROM play_history p
INNER JOIN channel c ON p.ChannelId = c.Id
WHERE c.Status = 'RUNNING'
GROUP BY p.ChannelId
LIMIT 50
)

SELECT c.Id AS ChannelId, c.Title AS ChannelTitle, p.MediaId FROM mediaDates i
INNER JOIN channel c ON c.Id = i.ChannelId
INNER JOIN play_history p ON i.lastDate = p.StartDateUTC AND p.ChannelId = c.Id";

            List<DbActiveChannel> channels;
            using (var conn = DataFactory.OpenConnection())
            {
                channels = (await conn.QueryAsync<DbActiveChannel>(sql)).ToList();
            }

            var ids = channels.Select(c => c.MediaId).ToList();
            var videosInfo = await youTubeCacheService.GetVideos(ids);

            var data = channels.Select(c =>
            {
                var video = videosInfo.FirstOrDefault(v => v.Id == c.MediaId);
                return new
                {
                    c.ChannelId,
                    c.ChannelTitle,
                    video?.Snippet?.Title,
                    c.MediaId
                };
            });
            return Ok(data);
        }

        public class DbActiveChannel
        {
            public Guid ChannelId { get; set; }
            public string ChannelTitle { get; set; }
            public string MediaId { get; set; }
        }
    }
}