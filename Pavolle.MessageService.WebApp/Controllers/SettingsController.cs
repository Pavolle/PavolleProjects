using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.SettingsRouteConsts.Route)]
    public class SettingsController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List(MessageServiceCriteriaBase criteria)
        {
            return Ok(SettingsManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            return Ok(SettingsManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] SettingRequest request)
        {
            return Ok(SettingsManager.Instance.Edit(oid, request));
        }
    }
}
