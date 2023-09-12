using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class EditUserGroupRequest:MessageServiceRequestBase
    {
        public string Name { get; set; }
        public EUserType? UserType { get; set; }
        public List<UserGroupAuthRequestModel> Auhtorizations { get; set; }
    }
}
