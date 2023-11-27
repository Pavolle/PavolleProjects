using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ClientLib
{
    public class AuthServerOrganizationServiceManager : Singleton<AuthServerOrganizationServiceManager>
    {
        private AuthServerOrganizationServiceManager() { }

        public string GetOrganizationNameFromOid(long creatorOrganizationOid)
        {
            throw new NotImplementedException();
        }
    }
}
