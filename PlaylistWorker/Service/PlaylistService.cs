using Dapper;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaylistWorker.Service
{
    public class PlaylistService
    {
        private readonly ILogger<PlaylistService> _log;

        public PlaylistService(ILogger<PlaylistService> log)
        {
            _log = log;
        }

        public async Task<PlayModel> PlayNext(Guid channelId)
        {
            using (var conn = DataFactory.OpenConnection())
            {
                var sql = @"BEGIN;
INSERT INTO play_history (ChannelId, MediaId, StartDateUTC, Duration) VALUES (@channelId, 
(SELECT JSON_VALUE(Playlist, '$[0].Id') FROM channel_playlist
WHERE ChannelId = @channelId FOR UPDATE),
UTC_TIMESTAMP,
(SELECT JSON_VALUE(Playlist, '$[0].Duration') FROM channel_playlist
WHERE ChannelId = @channelId FOR UPDATE)
);

UPDATE channel_playlist set Playlist = JSON_REMOVE(Playlist, '$[0]')
WHERE ChannelId = @channelId;

SELECT ChannelId, MediaId, StartDateUTC, Duration FROM play_history
WHERE ChannelId = @channelId
ORDER BY StartDateUTC DESC LIMIT 1;
COMMIT;";

                var res = await conn.QueryFirstOrDefaultAsync<PlayModel>(sql, new { channelId });
                return res;
            }
        }

        public async Task<IEnumerable<PlayModel>> LoadCurrentChannelMedia(List<Guid> channels)
        {
            var sql = @"WITH info AS(
SELECT c.Id, MAX(ph.StartDateUTC) AS lastItem FROM play_history ph
INNER JOIN channel c ON ph.ChannelId = c.Id
WHERE c.Id IN @channels
GROUP BY c.Id
)

SELECT ph.* FROM info i
INNER JOIN play_history ph ON ph.ChannelId = i.Id AND i.lastItem = ph.StartDateUTC
WHERE (StartDateUTC + INTERVAL Duration SECOND) > UTC_TIMESTAMP()";

            using (var conn = DataFactory.OpenConnection())
            {
                return await conn.QueryAsync<PlayModel>(sql, new { channels });
            }
        }
    }
}
