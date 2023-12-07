using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.PasswordServer.Business.Manager;
using Pavolle.BES.PasswordServer.Common.Utils;
using Pavolle.BES.PasswordServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(PasswordServerUrlConsts.ServerStatusUrlConst.BaseRoute)]
    public class ServerStatusController : Controller
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(PasswordServerUrlConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new PasswordServerStatusResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = PasswordServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new PasswordServerStatusResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }

        [HttpGet(PasswordServerUrlConsts.ServerStatusUrlConst.ServerSettingsRoutePrefix)]
        public ActionResult Settings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new PaswordServerSettingsResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = PasswordServerStatusManager.Instance.GetServerSettings(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new PaswordServerSettingsResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }

        [HttpPost(PasswordServerUrlConsts.ServerStatusUrlConst.ReloadAllServerSettingsRoutePrefix)]
        public ActionResult ReloadAllSettings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                SettingServiceManager.Instance.ReloadAllSettings();
                return Ok(new ResponseBase());
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }

    }
}
