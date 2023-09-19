using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class ApiServiceAuthViewData : ViewDataBase
    {
        public long UserGroupOid { get; set; }
        public string UserGroupName { get; set; }
        public bool IsAuthority { get; set; }
    }
}
