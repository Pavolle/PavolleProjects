using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.Surrvey.Business;
using Pavolle.BES.Surrvey.Common.Utils;
using Pavolle.BES.Surrvey.ViewModels.Criteria;
using Pavolle.BES.Surrvey.ViewModels.Request;
using Pavolle.BES.Surrvey.ViewModels.Response;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.Surrvey.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.SurveyConsts.BaseRoute)]
    public class SurveyController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SurveyController));

        [HttpGet(SurveyServerConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListSurveyCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (criteria.Language == null)
            {
                criteria.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = SurrveyManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SurveyListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(SurveyServerConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] LookupSurveyCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (criteria.Language == null)
            {
                criteria.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = SurrveyManager.Instance.Lookup(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(SurveyServerConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, BesRequestBase request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new SurveyDetailResponse
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
                var response = SurrveyManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(SurveyServerConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddSurveyRequest request)
        {
            if (request == null)
            {
                return BadRequest(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language= SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = SurrveyManager.Instance.Add(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new BesResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(SurveyServerConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditSurveyRequest request)
        {
            if (request == null ||oid==null || oid== 0)
            {
                return BadRequest(new SurveyDetailResponse
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
                var response = SurrveyManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new BesResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }
    
    }
}
