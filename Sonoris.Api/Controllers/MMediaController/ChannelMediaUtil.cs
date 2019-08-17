using DbManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sonoris.Api.Controllers.MMediaController.View;

namespace Sonoris.Api.Controllers.MMediaController
{
    public class ChannelMediaUtil
    {
        public static ChannelMediaView ToMediaView(Media media)
        {
            var v = new ChannelMediaView();
            v.id = media.MedId;
            v.name = media.MedName;
            return v;
        }
    }
}
