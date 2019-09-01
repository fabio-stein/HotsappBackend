using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Modules.MChannel
{
    public class ChannelViewModel
    {
        public int? chId { get; set; }
        public String chName { get; set; }
        public String chImage { get; set; }
        public String chCoverImage { get; set; }
    }
}
