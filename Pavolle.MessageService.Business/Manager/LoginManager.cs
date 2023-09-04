using DevExpress.Xpo;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using Pavolle.MessageService.WebSecurity;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class LoginManager : Singleton<LoginManager>
    {
        private List<UserCacheModel> _users;
        private LoginManager()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                ReloadUsers(session);
            }
        }

        public void ReloadUsers(Session session)
        {
            _users = session.Query<User>().Select(t => new UserCacheModel
            {
                Username = t.Username,
                PhoneNumber = t.PhoneNumber,
                Email = t.Email,
                WrongTryCount = t.WrongTryCount,
                IsLocked = t.IsLocked,
                Code = t.Code,
                Password = t.Password,
                UserGroupOid = t.UserGroup.Oid,
                UserType = t.UserGroup.UserType
            }).ToList();
        }

        public MessageServiceResponseBase ForgotPasword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public TokenResponse SignIn(LoginRequest request)
        {
            var response = new TokenResponse();

            if(request != null)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, ELanguage.Ingilizce);
                return response;
            }

            if (request.Language == null)
            {
                request.Language = ELanguage.Ingilizce;
            }

            string checkUsernameResult = ValidationManager.Instance.CheckString(request.Username, false, 5, 50, true);
            if(checkUsernameResult != null)
            {
                response.ErrorMessage = checkUsernameResult;
                return response;
            }

            string checkPasswordResult = ValidationManager.Instance.CheckString(request.Username, false, 8, 50, true);
            if (checkPasswordResult != null)
            {
                response.ErrorMessage = checkPasswordResult;
                return response;
            }

            var userCache = _users.FirstOrDefault(t => t.Username == request.Username);
            if (userCache == null)
            {
                //todo nameof(request.Username test edilecek.)
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UsernameOrPasswordIsNotCorrect, request.Language.Value);
                response.WrongTryCount = 0;
                response.IsLocked = false;
                return response;
            }

            if(userCache.IsLocked)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UserIsLocked, request.Language.Value);
                response.IsLocked = true;
                response.WrongTryCount = userCache.WrongTryCount;
                return response;
            }

            var authResult = SecurityHelperManager.Instance.GetEncryptedPassword(request.Password, request.Username) == userCache.Password;
            if (!authResult)
            {
                userCache.WrongTryCount++;
                if(userCache.WrongTryCount > 50)
                {
                    userCache.IsLocked = true;
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        //todo test edilecek. Burada bu bilgiliyi değiştirmemizin listede de değişiklik yapıp yapmadığını kontrol etmemiz gerekiyor.
                        userCache.IsLocked = true;

                        var user = session.Query<User>().FirstOrDefault(t => t.Username == request.Username);
                        user.IsLocked = true;
                        user.WrongTryCount = 50;
                        user.LastUpdateTime = DateTime.Now;
                        user.Save();
                        response.IsLocked = true; 
                        response.WrongTryCount = userCache.WrongTryCount;
                    }
                }
                else
                {
                    response.IsLocked = false;
                    response.WrongTryCount = userCache.WrongTryCount;
                }
                response.ErrorMessage=TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UsernameOrPasswordIsNotCorrect, request.Language.Value);
                return response;
            }

            response.Token = MesssageServiceJwtTokenManager.Instance.CreateToken(request.Username, Guid.NewGuid().ToString(), userCache.UserGroupOid.ToString(), ((int)userCache.UserType).ToString(), ((int)request.Language.Value).ToString(), request.RequestIp);

            response.Authorizations = AuthManager.Instance.GetAuthList(userCache.UserGroupOid);
            response.UserInfo = new UserInfoViewData
            {
                Name = userCache.Name,
                Surname = userCache.Surname,
                Username = userCache.Username,
                UserDefinition = UserGroupManager.Instance.GetUserGroupDefinition(userCache.UserGroupOid)
            };

            if (userCache.WrongTryCount > 10)
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var user = session.Query<User>().FirstOrDefault(t => t.Username == request.Username);
                    user.IsLocked = false;
                    user.WrongTryCount = 0;
                    user.LastUpdateTime = DateTime.Now;
                    user.Save();
                }
            }

            return response;
        }

        public MessageServiceResponseBase SignOut(MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase VerifyCode(VerifyCodeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
