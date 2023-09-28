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
    [Route(MessageServiceApiUrlConsts.CountryRouteConsts.Route)]
    public class CountryController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryController));

        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListCountryCriteria criteria)
        {
            try
            {
                var response = CountryManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }

        [HttpGet(MessageServiceApiUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] LookupCountryCriteria criteria)
        {
            try
            {
                var response = CountryManager.Instance.Lookup(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }

        [HttpGet(MessageServiceApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, MessageServiceRequestBase request)
        {
            try
            {
                var response = CountryManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditCountryRequest request)
        {
            try
            {
                var response = CountryManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.AddRoutePrefix)]
        public ActionResult Edit([FromBody] AddCountryRequest request)
        {
            try
            {
                var response = CountryManager.Instance.Add(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }

        [HttpDelete(MessageServiceApiUrlConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long? oid, [FromQuery] DeleteCountryCriteria request)
        {
            try
            {
                var response = CountryManager.Instance.Delete(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, ELanguage.English) });
            }
        }
    }
}
