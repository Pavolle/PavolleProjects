using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Model
{
    public class UserRoleCacheModel
    {
        public string Username { get; set; }
        public EUserType UserType { get; set; }
        public long? OrganizationOid { get; set; }
        public long? RoleOid { get; set; }
        public string RoleName { get; set; }
    }
}
