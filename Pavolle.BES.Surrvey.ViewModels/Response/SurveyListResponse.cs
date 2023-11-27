using Pavolle.BES.Surrvey.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.Response
{
    public class SurveyListResponse : BesResponseBase
    {
        public List<SurveyViewData> DataList { get; set; }
    }
}
