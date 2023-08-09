using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.VersionChangeRouteConsts.Route)]
    public class AppVersionChangeController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult Listele([FromQuery] VersionChangeCriteria criteria)
        {
            return Ok(AppVersionChangeManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detay(long? oid, MessageServiceRequestBase request)
        {
            return Ok(AppVersionChangeManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Ekle([FromBody] VersionChangeRequest request)
        {
            return Ok(AppVersionChangeManager.Instance.Add(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Duzenle(long? oid, [FromBody] VersionChangeRequest request)
        {
            return Ok(AppVersionChangeManager.Instance.Edit(oid, request));
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Sil(long oid, MessageServiceRequestBase request)
        {
            return Ok(AppVersionChangeManager.Instance.Delete(oid, request));
        }
    }
}
