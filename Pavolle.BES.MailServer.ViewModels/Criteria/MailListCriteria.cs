using Pavolle.BES.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.ViewModels.Criteria
{
    public class MailListCriteria : IntegrationAppRequestBase
    {
        public EBesAppType? BesAppType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool SendStatus { get; set; }
    }
}
