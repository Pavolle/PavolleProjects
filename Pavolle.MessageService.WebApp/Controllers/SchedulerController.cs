using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.SchedulerRouteConsts.Route)]
    public class SchedulerController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SchedulerController));

        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListSchedulerCriteria criteria)
        {
            try
            {
                var response = SchedulerManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            try
            {
                var response = SchedulerManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditSchedulerRequest request)
        {
            try
            {
                var response = SchedulerManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.SchedulerRouteConsts.RunRoutePrefix)]
        public ActionResult Run(long? oid, [FromBody] RunSchedulerRequest request)
        {
            try
            {
                var response = SchedulerManager.Instance.Run(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }
    }
}
