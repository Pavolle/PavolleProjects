using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.ViewModels.Integration.Request
{
    public class SuppleraIntegrationBomFileRequest : RequestBase
    {
        public long? OrganizationOid { get; set; }
        public long? ProductOid { get;set; }
        public long? VersionOid { get; set; }
        public string Base64File { get; set; }
    }
}
