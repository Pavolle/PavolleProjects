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
    [Route(MessageServiceApiUrlConsts.CityRouteConsts.Route)]
    public class CityController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CityController));

        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListCityCriteria criteria)
        {
            try
            {
                var response = CityManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] LookupCityCriteria criteria)
        {
            try
            {
                var response = CityManager.Instance.Lookup(criteria);
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
                var response = CityManager.Instance.Detail(oid, request);
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
        public ActionResult Edit(long? oid, [FromBody] EditCityRequest request)
        {
            try
            {
                var response = CityManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Edit([FromBody] AddCityRequest request)
        {
            try
            {
                var response = CityManager.Instance.Add(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long? oid, [FromQuery] DeleteCityCriteria request)
        {
            try
            {
                var response = CityManager.Instance.Delete(oid, request);
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
