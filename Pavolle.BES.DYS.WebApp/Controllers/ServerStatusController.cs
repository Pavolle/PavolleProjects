using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.DYS.Business.Manager;
using Pavolle.BES.DYS.Common.Utils;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using System.Text.Json;

namespace Pavolle.BES.DYS.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(DYSConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(DYSConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(BesRequestBase request)
        {
            try
            {
                var response = DYSServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new DysStatusResponse { ErrorMessage = "Unexpected error occured! Error Code: 500" });
            }
        }

        [HttpGet(DYSConsts.ServerStatusUrlConst.ServerSettingsRoutePrefix)]
        public ActionResult Settings(BesRequestBase request)
        {
            try
            {
                var response = DYSServerStatusManager.Instance.GetServerSettings(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new DYSSettingsResponse { ErrorMessage = "Unexpected error occured! Error Code: 500" });
            }
        }
    }
}
