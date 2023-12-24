using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.ViewModels.ViewData
{
    public class PasswordCategoryDetailViewData : ViewDataBase
    {
        public string Definition { get; set; }
        public bool? IsPersonal { get; set; }
        public long? BelongUserOid { get; set; }
        public PersonCacheModel BelongPersonInfo { get; set; }
    }
}
