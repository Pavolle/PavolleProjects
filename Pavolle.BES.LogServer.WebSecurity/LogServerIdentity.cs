using System.Security.Principal;

namespace Pavolle.BES.LogServer.WebSecurity
{
    public class LogServerIdentity : IIdentity
    {
        public LogServerIdentity(string name, string authenticationType)
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