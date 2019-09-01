using WhatsTroll.Api.Controllers.MMediaController.View;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Api.Controllers.MMediaController
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
