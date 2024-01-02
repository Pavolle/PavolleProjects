using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.GeoServer.Business.Manager;
using Pavolle.BES.GeoServer.Common.Utils;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.RequestValidation;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.GeoServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(GeoServerUrlConsts.CountryUrlConsts.BaseRoute)]
    public class CountryController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryController));

        [HttpGet(GeoServerUrlConsts.ListRoutePrefix)]
        public ActionResult List(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new CountryListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.List(request);
                _log.Debug("Request IP: " + request.RequestIp + " Criteria: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new CountryListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpGet(GeoServerUrlConsts.LookupRoutePrefix)]
        public ActionResult Lookup(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.Lookup(request);
                _log.Debug("Request IP: " + request.RequestIp + " Criteria: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpGet(GeoServerUrlConsts.ImageLookupRoutePrefix)]
        public ActionResult ImageLookup(IntegrationAppRequestBase reuest)
        {
            if (reuest == null)
            {
                return BadRequest(new ImageLookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (reuest.Language == null)
            {
                reuest.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.ImageLookup(reuest);
                _log.Debug("Request IP: " + reuest.RequestIp + " Criteria: " + JsonSerializer.Serialize(reuest) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, reuest.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpGet(GeoServerUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new CountryDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new CountryDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpPost(GeoServerUrlConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddCountryRequest request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.AddCountry(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpPost(GeoServerUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditCountryRequest request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);

                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }


        [HttpDelete(GeoServerUrlConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long? oid, IntegrationAppRequestBase request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = CountryManager.Instance.Delete(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }
    }
}
