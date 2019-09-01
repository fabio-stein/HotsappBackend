using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Controllers.MMediaController.Action
{
    public class ActionAddMedia
    {
        public String source { get; set; }
        public String title { get; set; }
        public int channel { get; set; }

        public bool addToPlaylist { get; set; }
    }
}
