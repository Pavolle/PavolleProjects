using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class CompanyEditRequest:MessageServiceRequestBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
