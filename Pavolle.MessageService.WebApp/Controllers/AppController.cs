using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.AppRouteConsts.Route)]
    public class AppController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult Listele([FromQuery] MessageServiceCriteriaBase criteria)
        {
            return Ok(AppManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] MessageServiceCriteriaBase criteria)
        {
            return Ok(AppManager.Instance.Lookup(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detay(long? oid, MessageServiceRequestBase request)
        {
            return Ok(AppManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Ekle([FromBody] AppRequest request)
        {
            return Ok(AppManager.Instance.Add(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Duzenle(long? oid, [FromBody] AppRequest request)
        {
            return Ok(AppManager.Instance.Edit(oid, request));
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Sil(long oid, MessageServiceRequestBase request)
        {
            return Ok(AppManager.Instance.Delete(oid, request));
        }
    }
}
