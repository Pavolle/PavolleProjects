using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.ViewModels.ViewData
{
    public class PasswordCategoryViewData : ViewDataBase
    {
        public string Definition { get; set; }
        public bool IsPersonal { get; set; }
    }
}
