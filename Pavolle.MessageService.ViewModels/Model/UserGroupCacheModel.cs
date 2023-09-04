using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class UserGroupCacheModel
    {
        public string Name { get; set; }
        public EUserType UserType { get; set; }
        public long? OrganizationOid { get; set; }
        public long Oid { get; set; }
        public string OrganizationName { get; set; }
    }
}
