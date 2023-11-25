using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Request
{
    public class AddSurveyRequest : BesRequestBase
    {
        public string About { get; set; }
        public string Header { get; set; }
        public string Base64Image { get; set; }
        public long? ResearchOwnerOrganizationOid { get; set; }
        public bool EncryptStringContent { get; set; }
        public bool MultiLanguage { get; set; }
        public ELanguage? CreatedLanguage { get; set; }
    }
}
