using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.LogServer.Business.Manager;
using Pavolle.BES.LogServer.Common.Utils;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.LogServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(LogServerConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(LogServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(LogServerRequestBase request)
        {
            try
            {
                var response = LogServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LogServerStatusResponse { ErrorMessage = "Unexpected error occured! Error Code: 500" });
            }
        }
    }
}
