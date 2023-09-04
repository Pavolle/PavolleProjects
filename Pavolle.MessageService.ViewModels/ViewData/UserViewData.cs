using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserViewData:MessageServiceViewDataBase
    {
        public long? OrganizationOid { get; set; }
        public string OrganizationName { get; set; }
        public long UserGroupOid { get; set; }
        public string UserGroupName { get; set; }
        public string Username { get; set; }
        public EUserType UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
