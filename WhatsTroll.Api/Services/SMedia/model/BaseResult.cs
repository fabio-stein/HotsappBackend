﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Services.SMedia.model
{
    public class BaseResult
    {
        public bool? error { get; set; }
        public String message { get; set; }
    }
}