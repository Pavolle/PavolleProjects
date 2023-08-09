using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.SchedulerRouteConsts.Route)]
    public class SchedulerController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List(MessageServiceCriteriaBase criteria)
        {
            return Ok(SchedulerManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            return Ok(SchedulerManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] SchedulerRequest request)
        {
            return Ok(SchedulerManager.Instance.Edit(oid, request));
        }

        [HttpGet(MessageServiceApiUrlConsts.SchedulerRouteConsts.RunRoutePrefix)]
        public ActionResult Run(long? oid,MessageServiceRequestBase request)
        {
            return Ok(SchedulerManager.Instance.Run(oid, request));
        }
    }
}
