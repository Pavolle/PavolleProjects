using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.ViewData
{
    public class UserGroupAuthViewData : ViewDataBase
    {
        public long ApiServiceOid { get; set; }
        public string ApiServiceName { get; set; }
        public bool IsAuhority { get; set; }
    }
}
