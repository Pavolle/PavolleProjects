using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.Business;
using Pavolle.BES.SettingServer.Common.Utils;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.SettingServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(SettingServerConsts.DefinitionUrlConst.BaseRoute)]
    public class DefinitionController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingsController));

        [HttpGet(SettingServerConsts.DefinitionUrlConst.GetSettingsTypeListRoutePrefix)]
        public ActionResult GetSettingsTypeList(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                _log.Warn("Request is null! Potential error  some property data type is not is not valid");
                return BadRequest(new LookupResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = DefinitionManager.Instance.GetSettingsTypeList();
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LookupResponse { ErrorMessage = "Unexpected error occured! ", StatusCode = 500 });
            }
        }

        [HttpGet(SettingServerConsts.DefinitionUrlConst.GetSettingsCategoriesListRoutePrefix)]
        public ActionResult GetSettingsCategoriesList(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                _log.Warn("Request is null! Potential error  some property data type is not is not valid");
                return BadRequest(new LookupResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = DefinitionManager.Instance.GetSettingsCategoriesList();
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LookupResponse { ErrorMessage = "Unexpected error occured! ", StatusCode = 500 });
            }
        }
    }
}
