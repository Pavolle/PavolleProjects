using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Request
{
    public class CompanyRequest:MessageServiceRequestBase
    {
        //TODO Üyelikle ilgili süreçlere daha sonra bakacağız.
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }

        public string AdminUsername { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string AdminPassword { get; set; }

    }
}
