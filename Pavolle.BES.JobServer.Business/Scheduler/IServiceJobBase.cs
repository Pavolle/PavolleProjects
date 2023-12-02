using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavolle.BES.JobServer.Business.Scheduler
{
    public interface IServiceJobBase
    {
        string JobName { get; }
        string JobGroup { get; }
        Type JobExecuteType { get; }
        string TriggerName { get; }
        string TriggerGroup { get; }
        string CronExpression { get; }
        EJobStatus JobStatus { get; }
        void Init();

        void Start(string cronExpression, params KeyValuePair<string, object>[] parameters);
        void Rescheduler(string cronExpression);
        void Pause();
        void Resume();
    }
}
