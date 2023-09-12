using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class ApiServiceViewData : MessageServiceViewDataBase
    {
        public string ApiKey { get; set; }
        public string ApiDefinition { get; set; }
        public EApiServiceMethodType MethodType { get; set; }
        public bool EditableForAdmin { get; set; }
        public bool EditableForOrganization { get; set; }
        public bool Anonymous { get; set; }
    }
}
