using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public object MyInfo(MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object EditMyInfo(EditMyInfoRequest request)
        {
            throw new NotImplementedException();
        }

        public object VerifyPhone(VerifyPhoneRequest request)
        {
            throw new NotImplementedException();
        }

        public object VerifyEmail(VerifyEmailRequest request)
        {
            throw new NotImplementedException();
        }

        public object SendVerificationCode(SendVerificationCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public object ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
