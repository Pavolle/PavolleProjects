using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.PasswordServer.Business.Manager;
using Pavolle.BES.PasswordServer.Common.Utils;
using Pavolle.BES.PasswordServer.ViewModels.Request;
using Pavolle.BES.PasswordServer.ViewModels.Response;
using Pavolle.BES.RequestValidation;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(PasswordServerUrlConsts.PasswordCategoryConsts.BaseRoute)]
    public class PasswordCategoryController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(PasswordCategoryController));

        [HttpGet(PasswordServerUrlConsts.PasswordCategoryConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] BesRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new PasswordCategoryListResponse
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
                return Unauthorized(new PasswordCategoryListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = PasswordCategoryManager.Instance.List(request);
                _log.Debug("Request IP: " + request.RequestIp + " Criteria: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new PasswordCategoryListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(PasswordServerUrlConsts.PasswordCategoryConsts.LookupRoutePrefix)]
        public ActionResult Lookup(BesRequestBase request)
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
            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = PasswordCategoryManager.Instance.Lookup(request);
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

        [HttpGet(PasswordServerUrlConsts.PasswordCategoryConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, BesRequestBase request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new PasswordCategoryDetailResponse
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
                return Unauthorized(new PasswordCategoryDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = PasswordCategoryManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new PasswordCategoryDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(PasswordServerUrlConsts.PasswordCategoryConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddPasswordCategoryRequest request)
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
            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = PasswordCategoryManager.Instance.Add(request);
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

        [HttpPost(PasswordServerUrlConsts.PasswordCategoryConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditPasswordCategoryRequest request)
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
            if (!BaseParameterValidationManager.Instance.Validate(request).Validated)
            {
                return Unauthorized(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = PasswordCategoryManager.Instance.Edit(oid, request);
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
