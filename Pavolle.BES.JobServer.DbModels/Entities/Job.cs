using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.DbModels.Entities
{
    [Persistent("jobs")]
    public class Job : BaseObject
    {
        public Job(Session session) : base(session)
        {
        }

        [Persistent("bes_app_type")]
        public EBesAppType BesAppType { get; set; }

        [Persistent("run_service_url")]
        [Size(255)]
        public string RunServiceUrl { get; set; }

        [Persistent("job_type")]
        public EBesJobType JobType { get; set; }

        [Persistent("cron")]
        public string Cron { get; set; }

        [Persistent("readable_name")]
        [Size(500)]
        public string ReadableName { get; set; }

        [Persistent("last_run_time")]
        public DateTime? LastRunTime { get; set; }

        [Persistent("send_mail_after_run")]
        public bool SendMailAfterRun { get; set; }

        [Persistent("mail_to")]
        [Size(500)]
        public string MailTo { get; set; }

        [Persistent("send_sms_after_run")]
        public bool SendSMSAfterRun { get; set; }

        [Persistent("sms_to")]
        [Size(500)]
        public string SMSTo { get; set; }

        [Persistent("active")]
        public bool Active { get; set; }
    }
}
