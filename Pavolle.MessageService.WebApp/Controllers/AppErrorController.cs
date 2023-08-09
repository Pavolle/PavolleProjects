using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.AppErrorRouteConsts.Route)]
    public class AppErrorController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] AppErrorCriteria criteria)
        {
            return Ok(AppErrorManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            return Ok(AppErrorManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AppErrorRequest request)
        {
            return Ok(AppErrorManager.Instance.Add(request));
        }
    }
}
