using Pavolle.BES.PasswordServer.ViewModels.ViewData;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.ViewModels.Response
{
    public class PasswordCategoryListResponse : ResponseBase
    {
        public List<PasswordCategoryViewData> DataList { get; set; }
    }
}
