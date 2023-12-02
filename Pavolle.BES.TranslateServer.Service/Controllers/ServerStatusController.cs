using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.Business.Manager;
using Pavolle.BES.TranslateServer.Common.Utils;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(TranslateServerConsts.ServerStatusUrlConst.Route)]
    public class ServerStatusController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));


        [HttpGet(TranslateServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateStatusManager.Instance.GetServerStatus(request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new TranslateServerStatusResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }


        [HttpGet(TranslateServerConsts.ServerStatusUrlConst.ServerSettingsRoutePrefix)]
        public ActionResult Settings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateStatusManager.Instance.GetServerSettings(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new TranslateServerSettingsResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }


        [HttpPost(TranslateServerConsts.ServerStatusUrlConst.ReloadAllServerSettingsRoutePrefix)]
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
