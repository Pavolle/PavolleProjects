using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Pavolle.MessageService.WebSecurity
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, string authenticationType)
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
