using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        private UserManager() { }

        public UserListResponse List(ListUserCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupUserCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public UserDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddUserRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditUserRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteUserCriteria request)
        {
            throw new NotImplementedException();
        }
        public MyInfoResponse MyInfo(MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase EditMyInfo(EditMyInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase VerifyPhone(VerifyPhoneRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase VerifyEmail(VerifyEmailRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase SendVerificationCode(SendVerificationCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
