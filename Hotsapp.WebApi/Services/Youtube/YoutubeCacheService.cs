using Google.Apis.YouTube.v3.Data;
using Hotsapp.Data.Util;
using MongoDB.Driver;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Services
{
    public class YouTubeCacheService
    {
        private ILogger _log = Log.ForContext<YouTubeCacheService>();
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<Video> _videoCollection;
        public YouTubeCacheService()
        {
            _db = MongoDataFactory.GetYoutubeDb();
            _videoCollection = _db.GetCollection<Video>("video");
        }

        public async Task SaveVideosCache(List<Video> items)
        {
            _log.Information("Saving cache for {0} video(s)", items.Count);
            var models = items.Select(video =>
            {
                var operation = new ReplaceOneModel<Video>(
                    new FilterDefinitionBuilder<Video>().Eq(v => v.Id, video.Id), video);
                operation.IsUpsert = true;
                return operation;
            });

            await _videoCollection.BulkWriteAsync(models);
            _log.Information("Videos cache sent successfully");
        }

        public async Task<List<Video>> GetVideos(List<string> ids)
        {
            var res = await _videoCollection.Find(c => ids.Contains(c.Id) && c.Status.Embeddable == true).ToListAsync();
            return res;
        }

        public async Task<Video> GetVideoInfo(string id)
        {
            var res = await _videoCollection.Find(c => c.Id == id && c.Status.Embeddable == true).FirstOrDefaultAsync();
            return res;
        }
    }
}
