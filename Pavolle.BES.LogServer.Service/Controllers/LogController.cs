using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.LogServer.Business.Manager;
using Pavolle.BES.LogServer.Common.Utils;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.LogServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(LogServerConsts.LogUrlConst.Route)]
    public class LogController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LogController));
        [HttpPost(LogServerConsts.LogUrlConst.SaveRoutePrefix)]
        public ActionResult Save([FromBody] LogRequest request)
        {
            try
            {
                var response = LogServerManager.Instance.Save(request);
                _log.Debug(request.LogBase + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
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
