using Pavolle.Core.ViewModels.Request;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class MessageServiceRequestBase:RequestBase
    {
        public string Username { get; set; }
        public EUserType? UserType { get; set; }
        public long? CompanyOid { get; set; }
        public string SessionId { get; set; }
    }
}
