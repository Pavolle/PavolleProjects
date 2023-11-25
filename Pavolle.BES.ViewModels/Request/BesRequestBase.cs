using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ViewModels.Request
{
    public class BesRequestBase : RequestBase
    {
        public EUserType UserType { get; set; }
        public long? OrganizationOid { get; set; }
        public long? UserOid { get; set; }
        public long? UserGroupOid { get; set; }
    }
}
