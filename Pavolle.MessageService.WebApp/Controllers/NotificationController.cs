using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.NotificationRouteConsts.Route)]
    public class NotificationController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult Listele([FromQuery] MessageServiceCriteriaBase criteria)
        {
            return Ok(NotificationManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detay(long? oid, MessageServiceRequestBase request)
        {
            return Ok(NotificationManager.Instance.Detail(oid, request));
        }
    }
}
