using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.ViewModels.Request
{
    public class AddJobRequest: IntegrationAppRequestBase
    {
        public EBesAppType? BesAppType { get; set; }
        public EBesJobType? JobType { get; set; }
        public string Cron { get; set; }
        public string ReadableName { get; set; }
        public string RunServiceUrl { get; set; }
        public string MailTo { get; set; }
        public bool? SendMailAfterRun { get; set; }
        public string SMSTo { get; set; }
        public bool? SendSMSAfterRun { get; set; }
        public bool? Active { get; set; }
    }
}
