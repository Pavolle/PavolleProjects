using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Model
{
    public class CommunicationInfoCacheModel
    {
        public long PersonOid { get; set; }
        public ECommunicationType CommunicationType { get; set; }
        public string Value { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDefault { get; set; }
        public long Oid { get; set; }
    }
}
