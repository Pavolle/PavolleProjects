using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.ViewModels.Integration.Request
{
    public class SuppleraIntegrationBomFileRequest : IntegrationAppRequestBase
    {
        public long? OrganizationOid { get; set; }
        public long? ProductOid { get;set; }
        public long? VersionOid { get; set; }
        public string Base64File { get; set; }

        //Product Name + Version Info
        public string FileName { get; set; }
    }
}
