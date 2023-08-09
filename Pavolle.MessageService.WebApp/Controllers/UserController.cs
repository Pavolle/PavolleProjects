using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.UserRouteConsts.Route)]
    public class UserController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] UserCriteria criteria)
        {
            return Ok(UserManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] UserCriteria criteria)
        {
            return Ok(UserManager.Instance.Lookup(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            return Ok(UserManager.Instance.Detail(oid, request));
        }

        [HttpGet(MessageServiceApiUrlConsts.UserRouteConsts.MyInfoRoutePrefix)]
        public ActionResult MyInfo(MessageServiceRequestBase request)
        {
            return Ok(UserManager.Instance.MyInfo( request));
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.ChangePasswordRoutePrefix)]
        public ActionResult ChangePassword([FromBody]ChangePasswordRequest request)
        {
            return Ok(UserManager.Instance.ChangePassword(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] UserRequest request)
        {
            return Ok(UserManager.Instance.Add(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] UserRequest request)
        {
            return Ok(UserManager.Instance.Edit(oid, request));
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long oid, MessageServiceRequestBase request)
        {
            return Ok(UserManager.Instance.Delete(oid, request));
        }
    }
}
