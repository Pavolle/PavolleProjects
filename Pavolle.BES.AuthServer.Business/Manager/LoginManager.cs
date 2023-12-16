using log4net;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.AuthServer.ViewModels.ViewData;
using Pavolle.BES.LogServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.WebSecurity;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class LoginManager : Singleton<LoginManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LoginManager));
        private LoginManager() { }

        public SignInResponse SignIn(LoginRequest request)
        {
            var response = new SignInResponse();
            try
            {
                //TODO Request Controls
                if (!UserManager.Instance.ValidateUser(request.Username, request.Password))
                {
                    response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UsernameOrPasswordNotCorrect, request.Language.Value);
                    response.StatusCode = 401;
                    return response;
                }

                var userInfo=UserManager.Instance.GetUserCacheDataByUsername(request.Username);
                if (userInfo == null)
                {
                    response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UsernameOrPasswordNotCorrect, request.Language.Value);
                    response.StatusCode = 401;
                    return response;
                }

                response.UserDetail = new SingInUserDetailViewData
                {
                    Name = userInfo.Name,
                    Surname = userInfo.Surname,
                    PhoneNumber=CommunicationInfoManager.Instance.GetPersonDefaultPhoneNumber(userInfo.PersonOid),
                    Email = CommunicationInfoManager.Instance.GetPersonDefaultEmailAddress(userInfo.PersonOid),
                    UserRoleList=RoleManager.Instance.GetUserRolesString(request.Username)
                };

                response.Token = BesJwtTokenManager.Instance.CreateToken(userInfo.Username, Guid.NewGuid().ToString(), RoleManager.Instance.GetUserRoleOid(userInfo.Username).ToString(), ((int)RoleManager.Instance.GetUserType(userInfo.Username)).ToString(), ((int)request.Language.Value).ToString(), request.RequestIp, DateTime.Now.ToString());

            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                LogServiceManager.Instance.SystemError("Unexpected error occured! Message: " + ex.Message + " StackTrace: " + ex.StackTrace);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }
    }
}
