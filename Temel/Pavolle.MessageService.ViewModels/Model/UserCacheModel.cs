using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class UserCacheModel
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WrongTryCount { get; set; }
        public bool IsLocked { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public long UserGroupOid { get; set; }
        public EUserType UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
