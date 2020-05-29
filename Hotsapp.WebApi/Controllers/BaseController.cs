using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public int? UserId
        {
            get
            {
                var id = User.FindFirst("UserId")?.Value;
                if (id == null)
                    return null;
                else
                    return int.Parse(id);
            }
        }
    }
}
