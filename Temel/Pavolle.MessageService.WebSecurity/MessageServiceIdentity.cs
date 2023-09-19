using System.Security.Principal;

namespace Pavolle.MessageService.WebSecurity
{
    public class MessageServiceIdentity : IIdentity
    {
        public MessageServiceIdentity(string name, string authenticationType)
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
