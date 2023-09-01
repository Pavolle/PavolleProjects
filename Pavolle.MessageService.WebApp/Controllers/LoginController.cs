using Microsoft.AspNetCore.Mvc;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.ViewModels.Request;

namespace Pavolle.MessageService.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(MessageServiceApiUrlConsts.LoginRouteConsts.Route)]
    public class LoginController : Controller
    {
        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignInRoutePrefix)]
        public ActionResult SignIn([FromBody] LoginRequest request)
        {
            return Ok(LoginManager.Instance.SignIn(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.SignOutRoutePrefix)]
        public ActionResult SignOut(MessageServiceRequestBase request)
        {
            return Ok(LoginManager.Instance.SignOut(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ForgotPaswordRoutePrefix)]
        public ActionResult ForgotPasword([FromBody]ForgotPasswordRequest request)
        {
            return Ok(LoginManager.Instance.ForgotPasword(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.VerifyCodeRoutePrefix)]
        public ActionResult VerifyCode([FromBody] VerifyCodeRequest request)
        {
            return Ok(LoginManager.Instance.VerifyCode(request));
        }

        [HttpPost(MessageServiceApiUrlConsts.LoginRouteConsts.ResetPaswordRoutePrefix)]
        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            return Ok(LoginManager.Instance.ResetPassword(request));
        }
    }
}
