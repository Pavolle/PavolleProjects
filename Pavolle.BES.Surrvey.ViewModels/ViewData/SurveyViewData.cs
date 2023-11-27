using Pavolle.BES.Surrvey.Common.Enums;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.ViewModels.ViewData
{
    public class SurveyViewData : ViewDataBase
    {
        public string Code { get; set; }
        public bool Approved { get; set; }
        public ESurveyStatus Status { get; set; }
        public bool Multilanguage { get; set; }
        public long TransactionCount { get; set; }
    }
}
