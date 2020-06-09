using Hotsapp.WebStreamer.Model;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Hubs
{
    public interface IStreamHub
    {
        Task PlayEvent(PlayModel data);
    }
}
