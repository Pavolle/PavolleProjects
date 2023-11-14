using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.SettingServer.Common.Utils;

namespace Pavolle.BES.SettingServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(SettingServerConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {
        [HttpGet(SettingServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail()
        {
            return Ok(ServerStatusManager.Instance.GetServerStatus());
        }
    }
}
