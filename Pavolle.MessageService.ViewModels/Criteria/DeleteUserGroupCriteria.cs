using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.ViewModels.Criteria
{
    public class DeleteUserGroupCriteria:MessageServiceCriteriaBase
    {
        public string UserGroupName { get; set; }
        public bool DeleteUsers { get; set; }
    }
}
