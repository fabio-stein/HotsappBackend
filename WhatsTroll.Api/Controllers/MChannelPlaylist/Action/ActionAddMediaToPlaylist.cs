using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Controllers.MChannelPlaylist
{
    public class ActionAddMediaToPlaylist
    {
        public long mediaId { get; set; }
        public int channel { get; set; }
    }
}
