using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.WebSecurity
{
    public class SettingsServerIdentity : IIdentity
    {
        public SettingsServerIdentity(string name, string authenticationType)
        {
            Name = name;
            IsAuthenticated = true;
            AuthenticationType = authenticationType;
        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}
