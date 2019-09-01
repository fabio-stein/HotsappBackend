using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Modules.MChannel
{
    public class ChannelEditForm
    {
        public int? Id { get; set; }
        public String Name { get; set; }

        public IFormFile Files { get; set; }
    }
}
