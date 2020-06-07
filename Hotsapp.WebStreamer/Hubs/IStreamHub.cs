using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Hubs
{
    public interface IStreamHub
    {
        Task PlayEvent(object data);
    }
}
