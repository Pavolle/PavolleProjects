using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.MessageManagmentRouteConsts.Route)]
    public class MessageManagmentController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult Listele([FromQuery] MessageManagmentCriteria criteria)
        {
            return Ok(MessageManagmentManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detay(long? oid, MessageServiceRequestBase request)
        {
            return Ok(MessageManagmentManager.Instance.Detail(oid, request));
        }

        //Cevap yazma, yeni mesaj oluşturma, Kullanıcıları seçme
    }
}
