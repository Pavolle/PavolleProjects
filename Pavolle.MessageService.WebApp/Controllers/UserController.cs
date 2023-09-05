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
    [Route(MessageServiceApiUrlConsts.UserRouteConsts.Route)]
    public class UserController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(UserGroupController));

        [HttpGet(MessageServiceApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListUserCriteria criteria)
        {
            try
            {
                var response = UserManager.Instance.List(criteria);
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
        public ActionResult Lookup([FromQuery] LookupUserCriteria criteria)
        {
            try
            {
                var response = UserManager.Instance.Lookup(criteria);
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
                var response = UserManager.Instance.Detail(oid, request);
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
        public ActionResult Edit(long? oid, [FromBody] EditUserRequest request)
        {
            try
            {
                var response = UserManager.Instance.Edit(oid, request);
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
        public ActionResult Edit([FromBody] AddUserRequest request)
        {
            try
            {
                var response = UserManager.Instance.Add(request);
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
        public ActionResult Delete(long? oid, [FromQuery] DeleteUserCriteria request)
        {
            try
            {
                var response = UserManager.Instance.Delete(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpGet(MessageServiceApiUrlConsts.UserRouteConsts.MyInfoRoutePrefix)]
        public ActionResult MyInfo(MessageServiceRequestBase request)
        {
            try
            {
                var response = UserManager.Instance.MyInfo(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.EditMyInfoRoutePrefix)]
        public ActionResult EditMyInfo(EditMyInfoRequest request)
        {
            try
            {
                var response = UserManager.Instance.EditMyInfo(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.VerifyPhoneRoutePrefix)]
        public ActionResult VerifyPhone(VerifyPhoneRequest request)
        {
            try
            {
                var response = UserManager.Instance.VerifyPhone(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.VerifyEmailRoutePrefix)]
        public ActionResult VerifyEmail(VerifyEmailRequest request)
        {
            try
            {
                var response = UserManager.Instance.VerifyEmail(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.SendVerificationCodeRoutePrefix)]
        public ActionResult SendVerificationCode(SendVerificationCodeRequest request)
        {
            try
            {
                var response = UserManager.Instance.SendVerificationCode(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MessageServiceResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, ELanguage.Ingilizce) });
            }
        }

        [HttpPost(MessageServiceApiUrlConsts.UserRouteConsts.ChangePasswordRoutePrefix)]
        public ActionResult ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var response = UserManager.Instance.ChangePassword(request);
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
