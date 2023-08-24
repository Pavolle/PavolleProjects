using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class AuthRequest:MessageServiceRequestBase
    {
        public string ApiDefinition { get; set; }
        public bool AdminAuth { get; set; }
        public bool CompanyAdminAuth { get; set; }
        public bool ProjectManagerAuth { get; set; }
        public bool DeveloperAuth { get; set; }
        public bool TecnicalSupportSpecialistAuth { get; set; }
        public bool LiveSupportSpecialistAuth { get; set; }
    }
}
