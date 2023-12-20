using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.DYS.Business.Manager;
using Pavolle.BES.DYS.Common.Utils;
using Pavolle.BES.DYS.ViewModels.Criteria;
using Pavolle.BES.DYS.ViewModels.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.RequestValidation;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.DYS.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(DYSConsts.FolderUrlConst.BaseRoute)]
    public class FolderController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(FolderController));

        [HttpGet(DYSConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListFolderCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new FolderListResponse
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
                return Unauthorized(new FolderListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = FolderManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new FolderListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(DYSConsts.LookupRoutePrefix)]
        public ActionResult Lookup([FromQuery] FolderLookupCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new LookupResponse
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
                return Unauthorized(new LookupResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = FolderManager.Instance.Lookup(criteria);
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

        [HttpGet(DYSConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, BesRequestBase request)
        {
            if (request == null || oid == null || oid == 0)
            {
                return BadRequest(new FolderDetailResponse
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
                return Unauthorized(new FolderDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnauthorizedException, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 401
                });
            }
            try
            {
                var response = FolderManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new FolderDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(DYSConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddFolderRequest request)
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
                var response = FolderManager.Instance.Add(request);
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

        [HttpPost(DYSConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditFolderRequest request)
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
                var response = FolderManager.Instance.Edit(oid, request);
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

        [HttpPost(DYSConsts.FolderUrlConst.MoveRoutePrefix)]
        public ActionResult Move([FromBody] MoveFolderRequest request)
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
                var response = FolderManager.Instance.Move(request);
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

        [HttpDelete(DYSConsts.DeleteRoutePrefix)]
        public ActionResult Delete(long? oid, BesRequestBase request)
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
                var response = FolderManager.Instance.Delete(oid, request);
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
