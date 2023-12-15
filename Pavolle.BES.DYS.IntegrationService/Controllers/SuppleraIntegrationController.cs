using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.DYS.Business.Integration;
using Pavolle.BES.DYS.Common.Utils;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.DYS.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(DYSIntegrationsConsts.SuppleraIntegrationUrlConsts.Route)]
    public class SuppleraIntegrationController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SuppleraIntegrationController));
        //yüklenen bom bilgisinin dosya olarak kaydedilmesi

        [HttpPost(DYSIntegrationsConsts.SuppleraIntegrationUrlConsts.SaveBomFileRoutePrefix)]
        public ActionResult SaveBomFile([FromBody] SuppleraIntegrationBomFileRequest request)
        {
            try
            {
                var response = SuppleraIntegrationManager.Instance.SaveBomFile(request);
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
