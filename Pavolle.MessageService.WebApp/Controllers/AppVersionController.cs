using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.VersionRouteConsts.Route)]
    public class AppVersionController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult Listele([FromQuery] AppVersionCriteria criteria)
        {
            return Ok(AppVersionManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] AppVersionCriteria criteria)
        {
            return Ok(AppVersionManager.Instance.Lookup(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detay(long? oid, MessageServiceRequestBase request)
        {
            return Ok(AppVersionManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Ekle([FromBody] AppVersionRequest request)
        {
            return Ok(AppVersionManager.Instance.Add(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Duzenle(long? oid, [FromBody] AppVersionRequest request)
        {
            return Ok(AppVersionManager.Instance.Edit(oid, request));
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Sil(long oid, MessageServiceRequestBase request)
        {
            return Ok(AppVersionManager.Instance.Delete(oid, request));
        }
    }
}
