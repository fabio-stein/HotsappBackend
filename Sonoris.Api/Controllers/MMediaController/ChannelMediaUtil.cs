using Sonoris.Api.Controllers.MMediaController.View;
using Sonoris.Data.Model;

namespace Sonoris.Api.Controllers.MMediaController
{
    public class ChannelMediaUtil
    {
        public static ChannelMediaView ToMediaView(Media media)
        {
            var v = new ChannelMediaView();
            v.id = media.Id;
            v.name = media.Title;
            return v;
        }
    }
}
