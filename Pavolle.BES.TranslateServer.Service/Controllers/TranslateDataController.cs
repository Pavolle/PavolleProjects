using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.TranslateServer.Business.Manager;
using Pavolle.BES.TranslateServer.Common.Utils;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(TranslateServerConsts.TranslateDataUrlConst.BaseRoute)]
    public class TranslateDataController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateDataController));

        [HttpGet(TranslateServerConsts.TranslateDataUrlConst.GetAllDataRoutePrefix)]
        public ActionResult GetAllData(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new TranslateDataListResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
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
                return Ok(new TranslateDataListResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }
    }
}
