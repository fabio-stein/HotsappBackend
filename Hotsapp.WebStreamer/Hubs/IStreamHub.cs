using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Hubs
{
    public interface IStreamHub
    {
        Task PlayEvent(object data);
    }
}
