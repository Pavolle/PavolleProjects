using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Model
{
    public class UserGroupAuthRequestModel
    {
        public long ApiServiceOid { get; set; }
        public bool IsAuthority { get; set; }
    }
}
