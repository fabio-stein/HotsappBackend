using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonoris.Api.Modules.MChannel
{
    public class ChannelEditForm
    {
        public int? chId { get; set; }
        public String chName { get; set; }

        public IFormFile files { get; set; }
    }
}
