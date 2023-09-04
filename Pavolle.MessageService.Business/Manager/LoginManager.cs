using DevExpress.Xpo;
using log4net;
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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pavolle.MessageService.Business.Manager
{
    public class LoginManager : Singleton<LoginManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(LoginManager));
        private List<UserCacheModel> _users;
        private LoginManager()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                ReloadUsers(session);
            }

            _log.Debug("Initialize " + nameof(LoginManager));
        }

        public void ReloadUsers(Session session)
        {
            _log.Debug("Kullanıcı cache listesi yenileniyor...");
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
            _log.Debug("Kullanıcı cache listesi yenileme tamamlandı.");
        }

        public MessageServiceResponseBase ForgotPasword(ForgotPasswordRequest request)
        {
            var response = new MessageServiceResponseBase();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, ELanguage.Ingilizce);
                    return response;
                }

                if (request.Language == null)
                {
                    request.Language = ELanguage.Ingilizce;
                }

                string checkResult = ValidationManager.Instance.CheckString(request.Username, false, 5, 50, true, EMessageServiceMessageCode.Username);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }
                checkResult = ValidationManager.Instance.CheckString(request.CommunicationValue, false, 5, 50, true, EMessageServiceMessageCode.CommunicationValue);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckEnum<ECommunicationType>((int?)request.CommunicationType, false, EMessageServiceMessageCode.CommunicationType);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                var userCache = _users.FirstOrDefault(t => t.Username == request.Username);
                if (userCache == null)
                {
                    //todo nameof(request.Username test edilecek.)
                    response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.Username);
                    return response;
                }

                bool communicationVerify = false;
                bool sendRestCodeResult = false;
                switch (request.CommunicationType.Value)
                {
                    case ECommunicationType.Phone:
                        communicationVerify = request.CommunicationValue == userCache.PhoneNumber;
                        if (communicationVerify)
                        {
                            sendRestCodeResult = CommunicationManager.Instance.GenerateResetCodeAndSendSMSToUser(userCache.Username);
                        }
                        break;
                    case ECommunicationType.Mail:
                        communicationVerify = request.CommunicationValue == userCache.Email;
                        if (communicationVerify)
                        {
                            sendRestCodeResult = CommunicationManager.Instance.GenerateResetCodeAndSendEmailToUser(userCache.Username);
                        }
                        break;
                    default:
                        break;
                }

                if (communicationVerify && sendRestCodeResult)
                {
                    switch (request.CommunicationType.Value)
                    {
                        case ECommunicationType.Phone:
                            response.InfoMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.CodeSendedToPhoneNumber, request.Language.Value);
                            break;
                        case ECommunicationType.Mail:
                            response.InfoMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.CodeSendedToEmailNumber, request.Language.Value);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (!communicationVerify)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, request.Language.Value);
                        return response;
                    }
                    else
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase ResetPassword(ResetPasswordRequest request)
        {
            var response = new MessageServiceResponseBase();
            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, ELanguage.Ingilizce);
                    return response;
                }

                if (request.Language == null)
                {
                    request.Language = ELanguage.Ingilizce;
                }

                string checkResult = ValidationManager.Instance.CheckString(request.Username, false, 5, 50, true, EMessageServiceMessageCode.Username);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }
                checkResult = ValidationManager.Instance.CheckString(request.CommunicationValue, false, 5, 50, true, EMessageServiceMessageCode.CommunicationValue);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckEnum<ECommunicationType>((int?)request.CommunicationType, false, EMessageServiceMessageCode.CommunicationType);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                var userCache = _users.FirstOrDefault(t => t.Username == request.Username);
                if (userCache == null)
                {
                    //todo nameof(request.Username test edilecek.)
                    response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.Username);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }
            return response;
        }

        public TokenResponse SignIn(LoginRequest request)
        {
            var response = new TokenResponse();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, ELanguage.Ingilizce);
                    return response;
                }

                if (request.Language == null)
                {
                    request.Language = ELanguage.Ingilizce;
                }

                string checkResult = ValidationManager.Instance.CheckString(request.Username, false, 5, 50, true, EMessageServiceMessageCode.Username);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckString(request.Password, false, 8, 50, true, EMessageServiceMessageCode.Password);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
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

                if (userCache.IsLocked)
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
                    if (userCache.WrongTryCount > 50)
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
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UsernameOrPasswordIsNotCorrect, request.Language.Value);
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

                var securityLevel = SettingManager.Instance.GetSecurityLevel();

                if (securityLevel != ESecurityLevel.Low)
                {
                    using (Session session = XpoManager.Instance.GetNewSession())
                    {
                        new UserSession(session)
                        {
                            Username = request.Username,
                            Token = response.Token,
                            RequestIp = request.RequestIp,
                            Active = true,
                        }.Save();

                        if (securityLevel == ESecurityLevel.Master)
                        {
                            var oldSessions = session.Query<UserSession>().Where(t => t.Username == request.Username).ToList();
                            foreach (var item in oldSessions)
                            {
                                item.Active = false;
                                item.LastUpdateTime = DateTime.Now;
                                item.Save();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase SignOut(MessageServiceRequestBase request)
        {
            var response = new MessageServiceResponseBase();
            try
            {

            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }
            return response;
        }

        public MessageServiceResponseBase VerifyCode(VerifyCodeRequest request)
        {
            var response = new MessageServiceResponseBase();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, ELanguage.Ingilizce);
                    return response;
                }

                if (request.Language == null)
                {
                    request.Language = ELanguage.Ingilizce;
                }

                string checkResult = ValidationManager.Instance.CheckString(request.Username, false, 5, 50, true, EMessageServiceMessageCode.Username);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }
                checkResult = ValidationManager.Instance.CheckString(request.CommunicationValue, false, 5, 50, true, EMessageServiceMessageCode.CommunicationValue);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckEnum<ECommunicationType>((int?)request.CommunicationType, false, EMessageServiceMessageCode.CommunicationType);
                if (checkResult != null)
                {
                    response.ErrorMessage = checkResult;
                    return response;
                }

                var userCache = _users.FirstOrDefault(t => t.Username == request.Username);
                if (userCache == null)
                {
                    //todo nameof(request.Username test edilecek.)
                    response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.Username);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }
    }
}
