using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ClientLib
{
    public class AuthServerUserServiceManager : Singleton<AuthServerUserServiceManager>
    {
        private AuthServerUserServiceManager() { }

        public PersonCacheModel GetPersonCacheModelFromUserOid(long? value)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameAndSurnameFromOid(long creatorUserOid)
        {
            throw new NotImplementedException();
        }
    }
}
