using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.IssueRouteConsts.Route)]
    public class AppIssueController : Controller
    {
        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] IssueCriteria criteria)
        {
            return Ok(IssueManager.Instance.List(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] IssueCriteria criteria)
        {
            return Ok(IssueManager.Instance.Lookup(criteria));
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            return Ok(IssueManager.Instance.Detail(oid, request));
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] IssueRequest request)
        {
            return Ok(IssueManager.Instance.Add(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] IssueRequest request)
        {
            return Ok(IssueManager.Instance.Edit(oid, request));
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long oid, MessageServiceRequestBase request)
        {
            return Ok(IssueManager.Instance.Delete(oid, request));
        }
    }
}
