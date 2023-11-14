using System.Security.Principal;

namespace Pavolle.BES.SettingServer.WebSecurity
{
    public class SettingsServerPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public string Ip { get; set; }

        public SettingsServerPrincipal(SettingsServerIdentity identity, string ip)
        {
            this.Ip = ip;
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }
}