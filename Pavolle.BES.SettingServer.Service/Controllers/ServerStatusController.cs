using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.SettingServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(SettingServerConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(SettingServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = ServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SettingsServerStatusResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }
    }
}
