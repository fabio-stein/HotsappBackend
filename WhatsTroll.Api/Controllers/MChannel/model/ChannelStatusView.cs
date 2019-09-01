using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Controllers.MChannel.model
{
    public class ChannelStatusView
    {
        public int Channel { get; set; }
        public String Name { get; set; }
        public bool Running { get; set; }
        public String RunningItem { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? Duration { get; set; }
    }
}
