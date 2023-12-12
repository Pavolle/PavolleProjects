using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.ViewData
{
    public class ApiServiceViewData : ViewDataBase
    {

        public string MethodType { get; set; }
        public bool EditableForAdmin { get; set; }
        public bool EditableForOrganization { get; set; }
        public bool Anonymous { get; set; }
        public string Key { get; set; }
        public string Definition { get; set; }
    }
}
