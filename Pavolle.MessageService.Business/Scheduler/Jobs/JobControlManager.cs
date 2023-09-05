using log4net;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Scheduler;
using System.Collections.Concurrent;

namespace Pavolle.MessageService.Business.Scheduler.Jobs
{
    public class JobControlManager : ServiceJobBase<JobControlManager>
    {
        private static ILog _log = LogManager.GetLogger(typeof(JobControlManager));
        private JobControlManager()
        {
        }

        public ConcurrentDictionary<EJobType, IServiceJobBase> RegisteredJobs = new ConcurrentDictionary<EJobType, IServiceJobBase>();

        public override void Start(string cronExpression, params KeyValuePair<string, object>[] parameters)
        {
            RegisteredJobs.Clear();

            //RegisterJob(EJobType.HelloChainControl, HelloChainControlJob.Instance);


            base.Start(cronExpression, parameters);
            _log.Debug("JobControl job started.");
        }

        public void Stop()
        {
            if (_scheduler == null) return;
            _scheduler.Shutdown(true);
            _jobStatus = EJobStatus.Stopped;

            _log.Info(string.Format("{0} durduruldu.", Name));
        }

        private void RegisterJob<T>(EJobType kod, ServiceJobBase<T> ins) where T : class
        {
            ins.Init();
            RegisteredJobs.TryAdd(kod, ins);
        }

        public override void Init()
        {
            Init(typeof(JobControlExecute));
        }

        public IServiceJobBase GetJob(EJobType? kod)
        {
            return kod.HasValue && RegisteredJobs.ContainsKey(kod.Value) ? RegisteredJobs[kod.Value] : null;
        }
    }
   
}
