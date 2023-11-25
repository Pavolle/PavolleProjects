using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.RequestValidation;
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
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.Surrvey.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(SurveyServerConsts.AnswerConsts.BaseRoute)]
    public class QuestionGroupController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(QuestionGroupController));

        [HttpGet(SurveyServerConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListQuestionGroupCriteria criteria)
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
            if(!BaseParameterValidationManager.Instance.Validate(criteria).Validated)
            {
                return Unauthorized(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = QuestionGroupManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new QuestionGroupListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(SurveyServerConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] LookupQuestionGroupCriteria criteria)
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
            if (!BaseParameterValidationManager.Instance.Validate(criteria).Validated)
            {
                return Unauthorized(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = QuestionGroupManager.Instance.Lookup(criteria);
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
            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = QuestionGroupManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new QuestionGroupDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(SurveyServerConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddQuestionGroupRequest request)
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
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = QuestionGroupManager.Instance.Add(request);
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
        public ActionResult Edit(long? oid, [FromBody] EditQuestionGroupRequest request)
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

            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new SurveyDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = QuestionGroupManager.Instance.Edit(oid, request);
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
