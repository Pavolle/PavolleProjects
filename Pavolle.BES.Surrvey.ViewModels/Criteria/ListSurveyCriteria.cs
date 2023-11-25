using Pavolle.BES.Surrvey.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Criteria
{
    public class ListSurveyCriteria : SurveyCriteriaBase
    {
        public long? OrganizationOid { get; set; }
        public ESurveyStatus ServeyStatus { get; set; }
    }
}
