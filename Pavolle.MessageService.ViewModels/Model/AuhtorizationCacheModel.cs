using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    internal class AuhtorizationCacheModel
    {
        public long UserGroupOid { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public string ApiKey { get; set; }
        public bool IsAuthority { get; set; }
    }
}
