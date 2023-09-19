using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserGroupDetailViewData : ViewDataBase
    {
        public long OrganizationOid { get; set; }
        public string Name { get; set; }
        public EUserType UserType { get; set; }
    }
}
