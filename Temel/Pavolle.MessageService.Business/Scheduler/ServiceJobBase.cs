using log4net;
using Pavolle.Core.Enums;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Pavolle.MessageService.Scheduler
{
    public abstract class ServiceJobBase<T> : IServiceJobBase where T : class
    {
        private static ILog log = LogManager.GetLogger(typeof(ServiceJobBase<T>));

        protected IScheduler _scheduler;
        private Type _jobExecuteType;
        private string _cronExpression = "";
        protected EJobStatus _jobStatus;

        protected string Name { get { return typeof(T).Name; } }

        public IScheduler Scheduler { get { return _scheduler; } }
        public string CronExpression { get { return _cronExpression; } }
        public EJobStatus JobStatus { get { return _jobStatus; } }
        public string JobName { get { return Name + "Job"; } }
        public string JobGroup { get { return Name + "JobGroup"; } }
        public Type JobExecuteType { get { return _jobExecuteType; } }
        public string TriggerName { get { return Name + "Trigger"; } }
        public string TriggerGroup { get { return Name + "TriggerGroup"; } }

        public abstract void Init();

        protected void Init(Type jobExecuteType)
        {
            _jobExecuteType = jobExecuteType;
            _jobStatus = EJobStatus.Start;
            _scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            _scheduler.Start();

            log.Debug(string.Format("{0} init...", Name));
        }


        public virtual void Start(string cronExpression, params KeyValuePair<string, object>[] parameters)
        {
            _cronExpression = cronExpression;
            IJobDetail jobDetail = new JobDetailImpl(JobName, JobGroup, _jobExecuteType, true, true);
            
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                jobDetail.JobDataMap.Add(pair);
            }
            ICronTrigger trigger = new CronTriggerImpl(TriggerName, TriggerGroup, _cronExpression);
            _scheduler.ScheduleJob(jobDetail, trigger);
            _jobStatus = EJobStatus.Started;

            log.Debug(string.Format("{0} started...", Name));
        }
        public virtual void Pause()
        {
            _scheduler.PauseJob(GetJobKey());
            _scheduler.PauseTrigger(GetTriggerKey());
            _jobStatus = EJobStatus.Paused;

            log.Debug(string.Format("{0} paused...", Name));
        }
        public virtual void Resume()
        {
            _scheduler.ResumeJob(GetJobKey());
            _scheduler.ResumeTrigger(GetTriggerKey());
            _jobStatus = EJobStatus.Resumed;

            log.Debug(string.Format("{0} resumed...", Name));
        }
        public virtual void Rescheduler(string cronExpression)
        {
            if (_cronExpression != cronExpression)
            {
                _scheduler.RescheduleJob(GetTriggerKey(), new CronTriggerImpl(TriggerName, TriggerGroup, cronExpression));
                _cronExpression = cronExpression;

                log.Debug(string.Format("{0} rescheduled...", Name));
            }
        }
        private JobKey GetJobKey()
        {
            return new JobKey(JobName, JobGroup);
        }
        private TriggerKey GetTriggerKey()
        {
            return new TriggerKey(TriggerName, TriggerGroup);
        }

        #region Singleton

        public static T Instance
        {
            get { return SingletonFactory.Instance; }
        }

        internal class SingletonFactory
        {
            static SingletonFactory()
            {
            }

            private SingletonFactory()
            {
            }

            internal static readonly T Instance = GetInstance();

            private static T GetInstance()
            {
                var theType = typeof(T);

                T inst;

                try
                {
                    inst =
                        (T)
                        theType.InvokeMember(theType.Name,
                                             BindingFlags.CreateInstance | BindingFlags.Instance |
                                             BindingFlags.NonPublic, null, null, null, CultureInfo.InvariantCulture);
                }
                catch (MissingMethodException ex)
                {
                    throw new TypeLoadException(
                        string.Format(CultureInfo.CurrentCulture,
                                      "The type '{0}' singleton tasarım örüntüsünde private constructor kullanılmalı.",
                                      theType.FullName), ex);
                }

                return inst;
            }
        }

        #endregion

    }
}
