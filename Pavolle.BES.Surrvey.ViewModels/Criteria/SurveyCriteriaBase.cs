using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Criteria
{
    public class SurveyCriteriaBase : BesRequestBase
    {
        public long? SelectedOrganizationOid { get; set; }
        public long? SurveyOid { get; set; }
    }
}
