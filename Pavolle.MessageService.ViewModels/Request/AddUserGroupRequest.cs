using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AddUserGroupRequest:MessageServiceRequestBase
    {

        public long? OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType? UserType { get; set; }
    }
}
