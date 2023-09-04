using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Request;
using System.Text.Json;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.LoginRouteConsts.Route)]
    public class LoginController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LoginController));

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignInRoutePrefix)]
        public ActionResult SignIn([FromBody] LoginRequest request)
        {
            var response = LoginManager.Instance.SignIn(request);
            _log.Debug("Request IP: "+ request.RequestIp+  " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
            return Ok(response);
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignOutRoutePrefix)]
        public ActionResult SignOut(MessageServiceRequestBase request)
        {
            var response = LoginManager.Instance.SignOut(request);
            _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
            return Ok(response);
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ForgotPaswordRoutePrefix)]
        public ActionResult ForgotPasword([FromBody]ForgotPasswordRequest request)
        {
            var response = LoginManager.Instance.ForgotPasword(request);
            _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
            return Ok(response);
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.VerifyCodeRoutePrefix)]
        public ActionResult VerifyCode([FromBody] VerifyCodeRequest request)
        {
            var response = LoginManager.Instance.VerifyCode(request);
            _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
            return Ok(response);
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ResetPaswordRoutePrefix)]
        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = LoginManager.Instance.ResetPassword(request);
            _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
            return Ok(response);
        }
    }
}
