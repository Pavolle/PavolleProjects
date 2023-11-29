using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.Business.Manager;
using Pavolle.BES.AuthServer.Common.Utils;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(BesAuthServerApiUrlConsts.ServerStatusUrlConsts.BaseRoute)]
    public class ServerStatusController : Controller
    {

        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(BesAuthServerApiUrlConsts.ServerStatusUrlConsts.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 400
                });
            }
            try
            {
                var response = AuthServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new AuthServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(BesAuthServerApiUrlConsts.ServerStatusUrlConsts.ServerSettingsRoutePrefix)]
        public ActionResult Settings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 400
                });
            }
            try
            {
                var response = AuthServerStatusManager.Instance.GetServerSettings(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new AuthServerSettingsResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(BesAuthServerApiUrlConsts.ServerStatusUrlConsts.ReloadAllServerSettingsRoutePrefix)]
        public ActionResult ReloadAllSettings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 400
                });
            }
            try
            {
                SettingServiceManager.Instance.ReloadAllSettings();
                return Ok(new ResponseBase());
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }

    }
}
