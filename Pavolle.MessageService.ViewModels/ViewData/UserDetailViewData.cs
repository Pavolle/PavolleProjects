using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserDetailViewData : ViewDataBase
    {
        public long UserGroupOid { get; set; }
        public string UserGroupName{ get; set; }
        public string Username { get; set; }
        public EUserType UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool EmailVerify { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberVerify { get; set; }
        public string Password { get; set; }
        public int WrongTryCount { get; set; }
        public bool IsLocked { get; set; }
        public string Code { get; set; }
    }
}
