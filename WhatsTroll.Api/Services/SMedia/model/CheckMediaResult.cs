using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Services.SMedia.model
{
    public class CheckMediaResult : BaseResult
    {
        public Video video { get; set; }
    }
}
