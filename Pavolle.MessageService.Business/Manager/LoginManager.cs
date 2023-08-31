using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.WebSecurity;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class LoginManager:Singleton<LoginManager>
    {
        public List<string> _users;
        private LoginManager()
        {
            //TODO Her yeni kullanıcı eklendiğinde bu alanın güncellenmesi gerekiyor.
            ReloadUsers();
        }

        void ReloadUsers()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _users=session.Query<User>().Select(t=>t.Username).ToList();
            }
        }

        public TokenResponse SignIn(LoginRequest request)
        {
            var response = new TokenResponse();
            if (_users.Any(t => t == request.Username))
            {
                //Hata
                response.Success = false;
                response.Token = "";
                return response;
            }
            bool signInSuccess = false;
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var user = session.Query<User>().FirstOrDefault(t => t.Username == request.Username);
                if(user==null)
                {
                    response.Success = false;
                    return response;
                }
                if (user.IsLocked)
                {
                    response.Success = false;
                    return response;
                }

                signInSuccess = user.Password == SecurityHelperManager.Instance.GetEncryptedPassword(request.Password, request.Username);
                if (!signInSuccess)
                {
                    user.WrongTryCount++;
                    if(user.WrongTryCount > 10)
                    {
                        user.IsLocked = true;
                    }
                    user.Save();
                    response.Success = false;
                    return response;
                }
                else
                {
                    user.IsLocked = false;
                    user.WrongTryCount = 0;
                    user.Save();
                }

                response.Token = MesssageServiceJwtTokenManager.Instance.CreateToken(user.Username, Guid.NewGuid().ToString(), user.Organization.Oid.ToString(), ((int)user.UserType).ToString(), request.Language.Value.ToString(), request.RequestIp);

                //yetkilerin sorgulanması.
                response.Name = user.Name;
                response.Surname = user.Surname;
                response.Email = user.Email;
                response.Username = user.Username;

                //response.Auths = AuthManager.Instance.GetAuthForUserType(user.UserType);
            }

            return response;
        }

        public MessageServiceResponseBase SignOut(MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? ForgotPasword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
