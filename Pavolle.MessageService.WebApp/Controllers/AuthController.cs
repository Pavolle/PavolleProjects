using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.AuthRouteConsts.Route)]
    public class AuthController : Controller
    {
        //[HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        //public ActionResult List(MessageServiceCriteriaBase criteria)
        //{
        //    return Ok(AuthManager.Instance.List(criteria));
        //}

        //[HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        //public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        //{
        //    return Ok(AuthManager.Instance.Detail(oid, request));
        //}

        //[HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        //public ActionResult Edit(long? oid, [FromBody] AuthRequest request)
        //{
        //    return Ok(AuthManager.Instance.Edit(oid, request));
        //}
    }
}
