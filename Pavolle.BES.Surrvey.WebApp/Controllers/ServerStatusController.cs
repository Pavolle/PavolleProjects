using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.Surrvey.Business;
using Pavolle.BES.Surrvey.Common.Utils;
using Pavolle.BES.Surrvey.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.Surrvey.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.ServerStatusUrlConst.BaseRoute)]
    public class ServerStatusController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));
        [HttpGet(SurveyServerConsts.ServerStatusUrlConst.ServerDetailRoutePrefix)]
        public ActionResult Detail(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new SurrveyServerStatusResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = SurrveyServerStatusManager.Instance.GetServerStatus(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SurrveyServerStatusResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }

        [HttpGet(SurveyServerConsts.ServerStatusUrlConst.ServerSettingsRoutePrefix)]
        public ActionResult Settings(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = SurrveyServerStatusManager.Instance.GetServerSettings(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SurrveyServerSettingsResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }
    }
}
