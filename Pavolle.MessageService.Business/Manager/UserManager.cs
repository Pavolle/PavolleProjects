using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class UserManager:Singleton<UserManager>
    {
        private UserManager()
        {

        }

        public object? Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? Edit(long? oid, UserRequest request)
        {
            throw new NotImplementedException();
        }

        public object? Add(UserRequest request)
        {
            throw new NotImplementedException();
        }

        public object? List(UserCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object? Lookup(UserCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object? MyInfo(MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object? ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        internal User CreateNewUser(Session session, Organization company, EUserType userType, string username, string name, string surname, string password, string phoneNumber, string email)
        {
            if (session.Query<User>().Any(t => t.Username == username))
            {
                return null;
            }
            User user = new User(session)
            {
                Username = username,
                Name = name,
                Surname = surname,
                UserType = userType,
                Email = email,
                PhoneNumber = phoneNumber,
                Organization = company,
                Password = SecurityHelperManager.Instance.GetEncryptedPassword(username, password),
            };
            user.Save();
            return user;
        }
    }
}
