using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.ViewModels.Request
{
    public class AddPasswordCategoryRequest : BesRequestBase
    {
        public string Definition { get; set; }
        public bool? IsPersonal { get; set; }
    }
}
