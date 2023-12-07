using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.ClientLib;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.PasswordServer.Common.Utils;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(PasswordServerUrlConsts.LoginUrlConsts.BaseRoute)]
    public class LoginController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LoginController));
        [HttpPost(PasswordServerUrlConsts.LoginUrlConsts.SignInRoutePrefix)]
        public ActionResult SignIn([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = AuthServerLoginServiceManager.Instance.SignIn(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }
    }
}
