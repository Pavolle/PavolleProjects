using Pavolle.BES.Surrvey.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Criteria
{
    public class ListSurveyCriteria : SurveyCriteriaBase
    {
        public List<ESurveyStatus>? StatusList { get; set; }
    }
}
