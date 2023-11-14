using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.SettingServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(SettingServerConsts.SettingsUrlConst.Route)]
    public class SettingsController : Controller
    {
        //list
        //detail //Değişiklik geçmişi de burada yer alacak.
        //edit

        static readonly ILog _log = LogManager.GetLogger(typeof(SettingsController));

        [HttpGet(SettingServerConsts.SettingsUrlConst.ListRoutePrefix)]
        public ActionResult List(SettingsServerRequestBase request)
        {
            try
            {
                var response = SettingsServerManager.Instance.List(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SettingListResponse { ErrorMessage = "Unexpected error occured! Error Code: 500" });
            }
        }

        [HttpGet(SettingServerConsts.SettingsUrlConst.DetailRoutePrefix)]
        public ActionResult Detail(int setting_type, SettingsServerRequestBase request)
        {
            try
            {
                var response = SettingsServerManager.Instance.Detail(setting_type, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SettingDetailResponse { ErrorMessage = "Unexpected error occured! Error Code: 500", Detail = new SettingViewData(), ChangeLogs= new List<SettingChangeLogViewData>() });
            }
        }

        [HttpPost(SettingServerConsts.SettingsUrlConst.EditRoutePrefix)]
        public ActionResult Edit(int setting_type, [FromBody] SettingRequest request)
        {
            try
            {
                var response = SettingsServerManager.Instance.Edit(setting_type, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase { ErrorMessage = "Unexpected error occured! Error Code: 500" });
            }
        }
    }
}
