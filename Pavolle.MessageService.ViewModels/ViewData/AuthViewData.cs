using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class AuthViewData:ViewDataBase
    {
        public string ApiKey { get; set; }
        public string ApiDefinition { get; set; }
        public bool AdminAuth { get; set; }
        public bool CompanyAdminAuth { get; set; }
        public bool ProjectManagerAuth { get; set; }
        public bool DeveloperAuth { get; set; }
        public bool TecnicalSupportSpecialistAuth { get; set; }
        public bool LiveSupportSpecialistAuth { get; set; }
        public bool Editable { get; set; }
        public bool Anonymous { get; set; }
    }
}
