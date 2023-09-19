using System.Security.Principal;

namespace Pavolle.B2B.WebSecurity
{
    public class B2BIdentity : IIdentity
    {
        public B2BIdentity(string name, string authenticationType)
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
