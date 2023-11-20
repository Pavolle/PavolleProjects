using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.LogServer.Business.Manager;
using Pavolle.BES.LogServer.Common.Utils;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.LogServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(LogServerConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(LogServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = LogServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug(request.LogBase+ " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LogServerStatusResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }

        [HttpGet(LogServerConsts.ServerStatusUrlConst.ServerSettingsRoutePrefix)]
        public ActionResult Settings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = LogServerStatusManager.Instance.GetServerSettings(request);
                _log.Debug(request.LogBase+ " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LogServerSettingsResponse { ErrorMessage = "Unexpected error occured!", StatusCode=500});
            }
        }
    }
}
